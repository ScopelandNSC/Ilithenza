#!/bin/sh

set -e

usage () {
    echo "Usage: $0 -b <string> -n <string>" 1>&2;
    exit 1;
}

while getopts ":b:n:" opt; do
  case $opt in
    b)
        # Build number to append to chart versions
        BUILD_NUMBER=$OPTARG
        ;;
    n)
        # Chart name to package
        CHART_NAME=$OPTARG
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

if [ -z "$BUILD_NUMBER" ] || [ -z "$CHART_NAME" ]; then
    usage
fi

mkdir /packages

# Loop over every dir in /charts and package them into /packages
cd /charts

/helm init --client-only

dir="./$CHART_NAME"

if [ ! -d "$dir" ]; then
    echo "Can't find directory: $PWD/$CHART_NAME" 1>&2;
    exit 1;
fi

/helm dependency build "$dir"
/helm lint "$dir"
VERSION="$BUILD_NUMBER"
if [ ! -f "$dir/requirements.lock" ] && [ -f "$dir/requirements.yaml" ] ; then
    echo "'$dir/requirements.lock' does not exist but requirements.yaml does, \
        run 'helm dependency update $dir' to create a .lock file"
    exit 1
fi
mkdir "$dir/tmpcharts"
/helm package --version "$VERSION" --save=false "$dir" -d /packages
