# dotnet-sample

Sample .NET application for demo purpose.

The application demonstrates step by step the transformation from a simple application repository to a fully automated release and deployment of a containerized application to kubernetes.

## Step-By-Step

1. Intial App: `git checkout app`
2. Workflow: `git checkout actions`
3. Semantic Release: `git checkout semrel`
4. Docker: `git checkout docker`
5. Kubernetes: `git checkout k8s`

## Deploy using actions worflow

If the [![Deploy Release](https://github.com/m4s-b3n/dotnet-sample/actions/workflows/deploy.yml/badge.svg?branch=main)](https://github.com/m4s-b3n/dotnet-sample/actions/workflows/deploy.yml) worfklow is successfull, the application is available under the FQDN from the deployment-environment.

## Build & run locally

Switch to the `/src` directory, execute `dotnet run --project voting -- --urls="http://localhost:8080"` and access the application at [http://localhost:8080](http://localhost:8080).

## Run with Docker

Execute `docker run -p 8080:8080 ghcr.io/m4s-b3n/dotnet-sample:latest` and access the application at [http://localhost:8080](http://localhost:8080).
