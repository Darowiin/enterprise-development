using AirCompany.Domain.Data;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirCompany.Infrastructure.Database;

public class AirCompanyDbContext(DbContextOptions<AirCompanyDbContext> options) : DbContext(options)
{
    public DbSet<AircraftFamily> AircraftFamilies { get; set; }
    public DbSet<AircraftModel> AircraftModels { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

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
        });

        modelBuilder.Entity<Ticket>(builder =>
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.SeatNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(t => t.SeatNumber).IsUnique();
        });
    }
}
