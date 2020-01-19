FROM gcr.io/kubernetes-helm/tiller:v2.13.0 as helm

USER root
ADD . /charts

ARG BUILD_NUMBER
ARG CHART_NAME

RUN chmod +x /charts/scripts/package_charts.sh
RUN /charts/scripts/package_charts.sh -b "${BUILD_NUMBER}" -n "${CHART_NAME}"
