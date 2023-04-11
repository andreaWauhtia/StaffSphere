#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["3T.Gestproj.Presentation/3T.Gestproj.Presentation.csproj", "3T.Gestproj.Presentation/"]
RUN dotnet restore "3T.Gestproj.Presentation/3T.Gestproj.Presentation.csproj"
COPY . .
WORKDIR "/src/3T.Gestproj.Presentation"
RUN dotnet build "3T.Gestproj.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "3T.Gestproj.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "3T.Gestproj.Presentation.dll"]