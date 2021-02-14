param (
    [Parameter(Mandatory = $true, HelpMessage = "The name of the Helm chart, directory or tarball to create a release from.")]
    [string]
    $packageName,

    [Parameter(Mandatory = $true, HelpMessage = "The name of the Helm release to create/upgrade.")]
    [string]
    $releaseName,

    [Parameter(Mandatory = $true, HelpMessage = "The Kubernetes namespace to create the release in.")]
    [string]
    $releaseNamespace,

    [Parameter(Mandatory = $false, HelpMessage = "The name of the YAML file to pass into the release (default '').")]
    [string]
    $valuesFileName = "",

    [Parameter(Mandatory = $false, 
        HelpMessage = "The time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 900).")]
    [string]
    $timeout = 900,

    [Parameter(Mandatory = $false, HelpMessage = "Enable TLS for request (default false)")]
    [string]
    $enableTls = "false",

    [Parameter(Mandatory = $false, HelpMessage = "Performs pods restart for the resource if applicable (default false)")]
    [string]
    $recreatePods = "false",

    [Parameter(Mandatory = $false, HelpMessage = "Simulate a release (default false)")]
    [string]
    $dryRun = "false",

    [Parameter(Mandatory = $true, HelpMessage = "The version of the image to deploy.")]
    [string]
    $releaseVersion
)

$ErrorActionPreference = "Stop"

$valuesArg = ""
if ("" -ne "$valuesFileName") {
    $valuesArg = "--values=$valuesFileName"
}

$releaseExists = $("$releaseName" -eq 
    $(helm list --all --short $releaseName `
            --tiller-connection-timeout=30 --tiller-namespace=helm --tls="$enableTls"))

if ($releaseExists) {
    $namespaceMatches = $("$releaseName" -eq `
        $(helm list --all --short $releaseName --namespace="$releaseNamespace" `
                --tiller-connection-timeout=30 --tiller-namespace=helm --tls="$enableTls"))
    if (-Not $namespaceMatches) {
        Write-Error "ERROR: Release namespace mismatch
            A release already exists with the name $releaseName, 
            but it was not deployed to the namespace $releaseNamespace
            To find the current release namespace, run:
            'helm ls --all $releaseName'"
        Exit 1
    }
}

$semVerPackageName = $packageName -replace "(\d+\.\d+\.\d+)\.(.*)", '$1-$2'

helm upgrade --install --reset-values --wait `
    --tiller-connection-timeout=30 --tiller-namespace=helm `
    --timeout="$timeout" `
    --namespace="$releaseNamespace" `
    --tls="$enableTls" `
    --recreate-pods="$recreatePods" `
    --dry-run="$dryRun" `
    --set "image.tag=$releaseVersion" `
    $valuesArg `
    "$releaseName" "$semVerPackageName"
