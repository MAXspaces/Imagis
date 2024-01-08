FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Imagist-Backend/Imagist-Backend.csproj", "Imagist-Backend/"]
COPY ["Imagist-Library/Imagist-Library.csproj", "Imagist-Library/"]
RUN dotnet restore "Imagist-Backend/Imagist-Backend.csproj"
COPY . .
WORKDIR "/src/Imagist-Backend"
RUN dotnet build "Imagist-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Imagist-Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Imagist-Backend.dll"]
