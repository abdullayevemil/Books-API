FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet publish -c Release -o dist



FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet

WORKDIR /app

COPY --from=build /src/dist .

ENTRYPOINT [ "dotnet", "Books-API.Presentation.dll" ]