# 1. Билд проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы решения и проекта
COPY task3/*.sln ./
COPY task3/*.csproj ./project/

# Восстанавливаем зависимости
RUN dotnet restore ./task3/task3.csproj

# Копируем остальной код
COPY . ./

# Собираем проект в Release
RUN dotnet publish ./task3/task3.csproj -c Release -o /app

# 2. Финальный контейнер
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Запуск
ENTRYPOINT ["dotnet", "task3.dll"]