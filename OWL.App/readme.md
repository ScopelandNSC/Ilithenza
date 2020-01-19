**ResDiary Web Application Template**

This is a template project for creating a React based .Net Core web application with a Web API REST backend.

**Components**
1. A Web API REST API. This is configured by adding controllers to the Controllers directory.
2. A React application based on create-react-app.  This is contained in the ClientApp directory.

**Infrastructure**

The project includes configuration for containerization in Docker and deployment with Kubernetes. A basic configuration for this is included but can be customised via `\Dockerfile` and the configuration files in `\Kubernetes\`.

**Health Checks**

A health check end point is available at `/health`. This will respond with a HTTP status of 200 if the application is healthy.

