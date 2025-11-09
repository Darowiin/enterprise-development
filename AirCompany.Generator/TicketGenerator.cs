using AirCompany.Application.Contracts.Ticket;
using AirCompany.Infrastructure.Database;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace AirCompany.Generator;

/// <summary>
/// Provides functionality for generating random <see cref="TicketCreateUpdateDto"/> contracts.
/// </summary>
public static class TicketGenerator
{
    private static readonly ConcurrentDictionary<string, bool> _usedSeats = [];
    private static readonly List<string> _allSeats = [];

    static TicketGenerator()
    {
        _allSeats = [.. Enumerable.Range(1, 50)
            .SelectMany(row => new[] { "A", "B", "C", "D", "E", "F" }
            .Select(col => $"{row}{col}"))];
    }

    /// <summary>
    /// Loads existing seat numbers from the database to avoid duplicates.
    /// </summary>
    public static async Task InitializeAsync(AirCompanyDbContext dbContext)
    {
        var seats = await dbContext.Tickets
            .Select(t => t.SeatNumber)
            .ToListAsync();

        _usedSeats.Clear();
        foreach (var s in seats)
            _usedSeats.TryAdd(s, true);
    }

    /// <summary>
    /// Generates a collection of randomly populated <see cref="TicketCreateUpdateDto"/> objects.
    /// </summary>
    /// <param name="count">The number of ticket contracts to generate.</param>
    /// <returns>A list of randomly generated <see cref="TicketCreateUpdateDto"/> instances.</returns>
    public static IList<TicketCreateUpdateDto>? GenerateContract(int count)
    {
        var tickets = new List<TicketCreateUpdateDto>(count);

        var faker = new Faker();

        var availableSeats = _allSeats.Where(s => !_usedSeats.ContainsKey(s)).ToList();

        if (availableSeats.Count < count)
            return null;

        for (var i = 0; i < count; i++)
        {
            var seat = availableSeats[faker.Random.Int(0, availableSeats.Count - 1)];
            _usedSeats.TryAdd(seat, true);
            availableSeats.Remove(seat);

            tickets.Add(new TicketCreateUpdateDto(
                faker.Random.Int(1, 10),
                faker.Random.Int(1, 30),
                seat,
                faker.Random.Bool(),
                faker.Random.Double(0, 25)
            ));
        }

        return tickets;
    }
}