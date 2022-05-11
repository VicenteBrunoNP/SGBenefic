FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj files as distinct layers.
# This is done because of the Docker's built in cache
# If we do not have changes in .csproj files
# Docker will not execute dotnet restore 
COPY SGBenefic.API/*.sln ./
COPY SGBenefic.API/SGBenefic.API/*.csproj ./SGBenefic.API/
RUN dotnet restore

COPY SGBenefic.API/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SGBenefic.API.dll"]