using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Application.Mapper;
using AirCompany.Application.Service;
using AirCompany.Domain.Data;
using AirCompany.Domain.Model;
using AirCompany.Infrastructure.InMemory.Repository;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(MappingRegister).Assembly);

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddSingleton<DataSeeder>();

builder.Services.AddSingleton<IRepository<Ticket, int>, TicketInMemoryRepository>();
builder.Services.AddSingleton<IRepository<Flight, int>, FlightInMemoryRepository>();
builder.Services.AddSingleton<IRepository<Passenger, int>, PassengerInMemoryRepository>();
builder.Services.AddSingleton<IRepository<AircraftModel, int>, AircraftModelInMemoryRepository>();
builder.Services.AddSingleton<IRepository<AircraftFamily, int>, AircraftFamilyInMemoryRepository>();

builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IApplicationService<TicketDto, TicketCreateUpdateDto, int>, TicketService>();
builder.Services.AddScoped<IApplicationService<PassengerDto, PassengerCreateUpdateDto, int>, PassengerService>();
builder.Services.AddScoped<IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int>, AirCraftModelService>();
builder.Services.AddScoped<IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>, AirCraftFamilyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
