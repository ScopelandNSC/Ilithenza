#!/bin/bash
set -e

function usage {
    echo "Usage: $0 -b <string>" 1>&2;
    exit 1;
}

while getopts ":b:" opt; do
  case $opt in
    b)
        # Build number to append to chart versions
        BUILD_NUMBER=$OPTARG
        ;;
    :)
        echo "Option -$OPTARG requires an argument." >&2
        usage
        ;;
    *)
        usage
        ;;
  esac
done

if [[ -z $BUILD_NUMBER ]]; then
    usage
fi

CHART_NAME="resdiary-webapp"
IMAGE_NAME="helm_charts:build"
CONTAINER_NAME="helm_charts"

function deleteTemp {

    if [[ "$(docker container ls -q -f name=$CONTAINER_NAME 2> /dev/null)" != "" ]]; then
        echo "Stopping container"
        docker stop $CONTAINER_NAME
    fi

    if [[ "$(docker image ls -q $IMAGE_NAME 2> /dev/null)" != "" ]]; then
        docker rmi $IMAGE_NAME
    fi
}

# Run deleteTemp on exit, also before trying to `docker run`
trap deleteTemp 0
deleteTemp

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
CHARTS_DIR="$DIR/.."

SEMVER=$(echo "$BUILD_NUMBER" | sed -E -e "s/([0-9]+\.[0-9]+\.[0-9]+)\.([0-9]+)/\1-\2/g")

docker build --no-cache \
    -f "$CHARTS_DIR/charts.Dockerfile" \
    -t $IMAGE_NAME \
    --build-arg BUILD_NUMBER="$SEMVER" \
    --build-arg CHART_NAME="$CHART_NAME" \
    "$CHARTS_DIR"

docker run -d --rm --name $CONTAINER_NAME $IMAGE_NAME /bin/sh -c "while : ; do sleep 10; done"
sleep 2

docker cp $CONTAINER_NAME:/packages/ "./release"
