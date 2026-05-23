### Stage: build (used by local/default target only, skipped in CI) ###
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY src/Voting/ .
RUN dotnet publish -c Release -o /app/publish

### Stage: runtime base (shared by both targets) ###
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER 1000:1000
EXPOSE 8080
EXPOSE 11111
WORKDIR /app
HEALTHCHECK CMD curl --fail http://localhost:8080 || exit 1
ENTRYPOINT ["dotnet", "Voting.dll"]
CMD ["--environment", "Development", "--urls", "http://0.0.0.0:8080"]

### Target: ci - copies pre-built artifacts from build context ###
FROM base AS ci
ARG PUBLISH_DIR=app
COPY ${PUBLISH_DIR} .

### Target: local (default) - builds inside Docker ###
FROM base AS local
COPY --from=build /app/publish .