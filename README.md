# AirCompany API

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/C%23-12.0-blue)
![Mapster](https://img.shields.io/badge/Mapster-7.4.0-orange)

## Структура проекта

### Domain:

Хранит основные сущности: Flight, Ticket, Passenger, AircraftModel, AircraftFamily и DataSeeder, хранящий тестовые данные

### Infrastructure.InMemory:

In-memory репозитории для работы с коллекциями объектов без базы данных

Репозитории наследуются от общего InMemoryRepository, который реализует интерфейс IRepository<TEntity, int>

### Infrastructure.Database:

Реализация репозиториев через Entity Framework Core с использованием Postgres

Содержит:

- AirCompanyDbContext - конфигурация сущностей, связей, ключей, индексов
- DbSeeder - класс для наполнения базы начальными данными из DataSeeder
- Migrations (автоматически генерируемые миграции)
- Repository для каждой сущности

### Application.Contracts

DTO-классы двух видов для каждой сущности:
- EntityDto - для получения сущностей из запросов
- EntityCreateUpdateDto - для создания и изменения сущностей

А также интерфейсы для сервисов, реализованные в проекте Application

### Application

Сервисы реализуют интерфейсы из Contracts и используют Mapster для маппинга между DTO и Entity сущностями

### Api.Host

Контроллеры, наследующие CrudControllerBase

Методы для CRUD и дополнительных запросов: топ-5 рейсов, рейсы по модели, рейсы с минимальной длительностью и т.д

Использует логирование через ILogger

### App.Host

Проект для Aspire оркестратора: AppHost.cs регистрирует и запускает контейнеры с параметрами из appsettings.json

### ServiceDefaults 

Содержит стандартные настройки приложения и расширения для быстрой конфигурации сервисов

Основные функции:

OpenTelemetry — настройка логирования, метрик и трассировки HTTP и ASP.NET

Health Checks — дефолтные эндпоинты /health и /alive для проверки состояния приложения

Service Discovery — интеграция с механизмом обнаружения сервисов

HTTP-клиенты — стандартные настройки, включая обработку отказов (resilience) и интеграцию с сервис-дискавери

### Tests

AirCompanyFixture для инициализации и заполнения коллекций репозиториев

Unit-тесты проверяют необходимую бизнес-логику доменных сущностей и репозиториев