using AirCompany.Domain.Data;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirCompany.Infrastructure.Database;

/// <summary>
/// EF Core database context for domain.
/// Configures entities, relationships, and value converters.
/// </summary>
public class AirCompanyDbContext(DbContextOptions<AirCompanyDbContext> options, DataSeeder seeder) : DbContext(options)
{
    /// <summary>
    /// Aircraft families in the database.
    /// </summary>
    public DbSet<AircraftFamily> AircraftFamilies { get; set; }

    /// <summary>
    /// Aircraft models in the database.
    /// </summary>
    public DbSet<AircraftModel> AircraftModels { get; set; }

    /// <summary>
    /// Passengers in the database.
    /// </summary>
    public DbSet<Passenger> Passengers { get; set; }

    /// <summary>
    /// Flights in the database.
    /// </summary>
    public DbSet<Flight> Flights { get; set; }

    /// <summary>
    /// Tickets in the database.
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }

    /// <summary>
    /// Configures entity relationships, keys, indexes, and value conversions.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entities.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                        v => v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                    ));
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new ValueConverter<DateTime?, DateTime?>(
                        v => v.HasValue ? v.Value.ToUniversalTime() : v,
                        v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
                    ));
                }
            }
        }

        modelBuilder.Entity<AircraftFamily>(builder =>
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(f => f.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(80);
            
            builder.HasMany(f => f.Models)
                    .WithOne(m => m.Family)
                    .HasForeignKey(m => m.FamilyId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(seeder.Families);
        });

        modelBuilder.Entity<AircraftModel>(builder =>
        {
            builder.HasKey(m => m.Id);

            builder.Property(f => f.ModelName)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(f => f.FlightRangeKm)
               .IsRequired();
            builder.Property(f => f.PassengerCapacity)
                .IsRequired();
            builder.Property(f => f.CargoCapacityKg)
                .IsRequired();

            builder.HasMany(m => m.Flights)
                    .WithOne(f => f.Model)
                    .HasForeignKey(f => f.ModelId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(seeder.Models);
        });

        modelBuilder.Entity<Passenger>(builder =>
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PassportNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(p => p.Tickets)
               .WithOne(t => t.Passenger)
               .HasForeignKey(t => t.PassengerId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(seeder.Passengers);
        });

        modelBuilder.Entity<Flight>(builder =>
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Code)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(f => f.DepartureAirport)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(f => f.ArrivalAirport)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(f => f.Code).IsUnique();

            builder.HasMany(f => f.Tickets)
               .WithOne(t => t.Flight)
               .HasForeignKey(t => t.FlightId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(seeder.Flights);
        });

        modelBuilder.Entity<Ticket>(builder =>
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.SeatNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(t => new { t.FlightId, t.SeatNumber }).IsUnique();

            builder.HasData(seeder.Tickets);
        });
    }
}
