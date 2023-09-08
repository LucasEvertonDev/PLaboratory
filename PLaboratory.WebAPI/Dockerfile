#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PLaboratory.WebAPI/PLaboratory.WebAPI.csproj", "PLaboratory.WebAPI/"]
COPY ["PLaboratory.Infra/PLaboratory.Infra.IoC/PLaboratory.Infra.IoC.csproj", "PLaboratory.Infra/PLaboratory.Infra.IoC/"]
COPY ["PLaboratory.Core/PLaboratory.Core.Application/PLaboratory.Core.Application.csproj", "PLaboratory.Core/PLaboratory.Core.Application/"]
COPY ["PLaboratory.Core/PLaboratory.Core.Domain/PLaboratory.Core.Domain.csproj", "PLaboratory.Core/PLaboratory.Core.Domain/"]
COPY ["PLaboratory.Infra/PLaboratory.Infra.Data/PLaboratory.Infra.Data.csproj", "PLaboratory.Infra/PLaboratory.Infra.Data/"]
RUN dotnet restore "PLaboratory.WebAPI/PLaboratory.WebAPI.csproj"
COPY . .
WORKDIR "/src/PLaboratory.WebAPI"
RUN dotnet build "PLaboratory.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PLaboratory.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PLaboratory.WebAPI.dll"]