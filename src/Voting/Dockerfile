FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
USER 1000:1000
EXPOSE 8080
EXPOSE 11111
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD curl --fail http://localhost:8080 || exit 1
ENTRYPOINT ["dotnet", "Voting.dll"]
CMD ["--environment", "Development", "--urls", "http://0.0.0.0:8080"]