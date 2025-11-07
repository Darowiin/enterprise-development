using AirCompany.Application.Contracts.Ticket;
using Bogus;

namespace AirCompany.Generator;

/// <summary>
/// Provides functionality for generating random <see cref="TicketCreateUpdateDto"/> contracts.
/// </summary>
public static class TicketGenerator
{
    /// <summary>
    /// Generates a collection of randomly populated <see cref="TicketCreateUpdateDto"/> objects.
    /// </summary>
    /// <param name="count">The number of ticket contracts to generate.</param>
    /// <returns>A list of randomly generated <see cref="TicketCreateUpdateDto"/> instances.</returns>
    public static IList<TicketCreateUpdateDto> GenerateContract(int count) =>
        new Faker<TicketCreateUpdateDto>()
            .CustomInstantiator(f => new TicketCreateUpdateDto(
                f.Random.Int(1, 10),
                f.Random.Int(1, 30),
                f.Random.Number(1, 40) + f.Random.String2(1, "ABCDEFG"),
                f.Random.Bool(),
                f.Random.Double(0, 25)
            ))
            .Generate(count);
}