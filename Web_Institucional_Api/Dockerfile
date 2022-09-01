#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web_Institucional_Api/Web_Institucional_Api.csproj", "Web_Institucional_Api/"]
RUN dotnet restore "Web_Institucional_Api/Web_Institucional_Api.csproj"
COPY . .
WORKDIR "/src/Web_Institucional_Api"
RUN dotnet build "Web_Institucional_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web_Institucional_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_Institucional_Api.dll"]