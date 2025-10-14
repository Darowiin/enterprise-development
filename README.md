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

### Tests

AirCompanyFixture для инициализации и заполнения коллекций репозиториев

Unit-тесты проверяют необходимую бизнес-логику доменных сущностей и репозиториев