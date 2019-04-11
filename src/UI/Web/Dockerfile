FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64630
EXPOSE 44300

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/UI/Web/Web.csproj src/UI/Web/
COPY src/Infrastructure/Infrastructure.csproj src/Infrastructure/
COPY src/Core/Core.csproj src/Core/
RUN dotnet restore src/UI/Web/Web.csproj
COPY . .
WORKDIR /src/src/UI/Web
RUN dotnet build Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Web.dll"]
