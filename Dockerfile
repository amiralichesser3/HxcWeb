FROM nginx:alpine AS base
USER $APP_UID
WORKDIR /usr/share/nginx/html
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore HxcUi project (Razor Class Library)
COPY ["HxcUi/HxcUi.csproj", "./HxcUi/"]
RUN dotnet restore "HxcUi/HxcUi.csproj"

# Copy and restore HxcWeb project
COPY ["HxcWeb/HxcWeb.csproj", "./HxcWeb/"]
RUN dotnet restore "HxcWeb/HxcWeb.csproj"


# Copy the entire solution
COPY . .

# Build both projects
WORKDIR "/src/"
RUN dotnet build "HxcUi/HxcUi.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "HxcWeb/HxcWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publish both projects
RUN dotnet publish "HxcWeb/HxcWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]