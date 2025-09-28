# 1. Билд проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл решения и проекта из папки task3
COPY task3/task3.sln .
COPY task3/task3/task3.csproj ./task3/

# Восстанавливаем зависимости
RUN dotnet restore

# Копируем остальные исходные файлы
COPY task3/task3/ ./task3/

# Собираем проект в Release
RUN dotnet publish task3/task3.csproj -c Release -o /app

# 2. Финальный контейнер
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Запуск
ENTRYPOINT ["dotnet", "task3.dll"]
