# ResDiary resdiary-webapp Chart

This chart installs the resdiary-webapp.

## Configuration

Before you can use this chart you will need to setup a `values.local.yaml` file to store your local configuration settings. This will need to override the following settings

| Setting                | Description  |
| ---------------------- | ----- |

## Installing

To install this chart, use the following:

```shell
helm dependency build ./charts/resdiary-webapp
helm upgrade resdiary-webapp ./charts/resdiary-webapp -f ./charts/resdiary-webapp/values.local.yaml --install --namespace default
```

This will install a copy of the resdiary-webapp chart called
*resdiary-webapp*, into the Kubernetes namespace *default*.

**NOTE:** `helm dependency build` only needs to be run whenever the chart's
dependencies change. In practice this means whenever you edit the [requirements.yaml](requirements.yaml)
file, or if you pull in changes from git that update the requirements file.

## Accessing Services

The chart defaults to installing the services for accessing its components as
NodePorts. This means that you can easily access the services via
`localhost:<nodePort>`. The following table lists the default port numbers used:

| Service                | Port  | Example URL              |
| ---------------------- | ----- | ------------------------ |
| web                    | 31140 | <http://localhost:31140> |
| metrics                | 31141 | <http://localhost:31141> |


## FAQs

**Q: My machine could not find tiller after running the above command, what do I do?**

Tiller is the in-cluster component of Helm. It interacts directly with the Kubernetes API server to install, upgrade, query, and remove Kubernetes resources. To install it, use the following command:

```
helm init
```

**Q: I have installed tiller but my terminal reports 'Error: could not find a ready tiller pod'**

Once you have installed tiller on your machine, it may take a few minutes for the tiller pod to start. You can check the status of the pod by using the command below - once it reports **running**, try re-running the above command again.

```
kubectl -n kube-system get po
```

**Q: Where do I put the values.local.yaml file?**

This should be placed here: /RD.Webapp.Template/charts/resdiary-webapp/values.local.yaml
