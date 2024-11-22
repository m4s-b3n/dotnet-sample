---
languages:
  - csharp
products:
  - dotnet
  - dotnet-orleans
page_type: sample
name: "Orleans Voting sample app on Kubernetes"
urlFragment: "orleans-voting-sample-app-on-kubernetes"
description: "An Orleans sample demonstrating a voting app on Kubernetes."
---

# Orleans Voting sample app on Kubernetes

![A screenshot of the application](./screenshot.png)

This is an [Orleans](https://github.com/dotnet/orleans) sample application.
The application is a simplistic Web app for voting on a custom set of options.
The application uses [.NET Generic Host](https://docs.microsoft.com/dotnet/core/extensions/generic-host) to co-host [ASP.NET Core](https://docs.microsoft.com/aspnet/core) and Orleans as well as the [Orleans Dashboard](https://github.com/OrleansContrib/OrleansDashboard) together in the same process.

![A screenshot of the Orleans dashboard](./dashboard.png)

The Web app sends HTTP requests which are handled by ASP.NET Core MVC controllers which call into Orleans grains.

## Sample prerequisites

This sample is written in C# and targets .NET 7.0. It requires the [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later.

## Building the sample

The application can be run locally by executing:

```powershell
dotnet run -c Release --project Voting -- --environment Development --urls http://localhost:5000
```

Once the application starts, open a browser to <http://localhost:5000> to play with the app. The Orleans Dashboard will be available at <http://localhost:8888.>
