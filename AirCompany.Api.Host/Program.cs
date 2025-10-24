using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Application.Mapper;
using AirCompany.Application.Service;
using AirCompany.Domain;
using AirCompany.Domain.Data;
using AirCompany.Domain.Model;
using AirCompany.Infrastructure.Database;
using AirCompany.Infrastructure.Database.Repository;
using AirCompany.ServiceDefaults;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(MappingRegister).Assembly);

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddSingleton<DataSeeder>();

builder.Services.AddScoped<IRepository<Ticket, int>, TicketDatabaseRepository>();
builder.Services.AddScoped<IRepository<Flight, int>, FlightDatabaseRepository>();
builder.Services.AddScoped<IRepository<Passenger, int>, PassengerDatabaseRepository>();
builder.Services.AddScoped<IRepository<AircraftModel, int>, AircraftModelDatabaseRepository>();
builder.Services.AddScoped<IRepository<AircraftFamily, int>, AircraftFamilyDatabaseRepository>();

builder.Services.AddScoped<IFlightCrudService, FlightService>();
builder.Services.AddScoped<ITicketCrudService, TicketService>();
builder.Services.AddScoped<IPassengerCrudService, PassengerService>();
builder.Services.AddScoped<IAircraftModelReadService, AirCraftModelService>();
builder.Services.AddScoped<IAircraftFamilyReadService, AirCraftFamilyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.AddNpgsqlDbContext<AirCompanyDbContext>("Database", configureDbContextOptions: builder => builder.UseLazyLoadingProxies());

var app = builder.Build();

app.MapDefaultEndpoints();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AirCompanyDbContext>();

    await context.Database.MigrateAsync();

    var seeder = new DbSeeder(context);
    await seeder.Seed();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
