using AirCompany.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database;

public class DbSeeder(AirCompanyDbContext context)
{
    public async Task Seed()
    {
        var seed = new DataSeeder();

        var anyData =
            await context.AircraftFamilies.AnyAsync() ||
            await context.AircraftModels.AnyAsync() ||
            await context.Flights.AnyAsync() ||
            await context.Passengers.AnyAsync() ||
            await context.Tickets.AnyAsync();

        if (anyData)
            return;

        await context.AircraftFamilies.AddRangeAsync(seed.Families);
        await context.SaveChangesAsync();

        await context.AircraftModels.AddRangeAsync(seed.Models);
        await context.SaveChangesAsync();

        await context.Passengers.AddRangeAsync(seed.Passengers);
        await context.SaveChangesAsync();

        await context.Flights.AddRangeAsync(seed.Flights);
        await context.SaveChangesAsync();

        await context.Tickets.AddRangeAsync(seed.Tickets);
        await context.SaveChangesAsync();
    }
}