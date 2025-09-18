namespace AirCompany.Domain.Models;

/// <summary>
/// Represents a <see cref="Passenger"/> who can purchase <see cref="Ticket"/>s.
/// </summary>
public class Passenger
{
    /// <summary>
    /// Unique identifier of the <see cref="Passenger"/>.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Passport number of the <see cref="Passenger"/>.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Full name of the <see cref="Passenger"/>.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Date of birth of the <see cref="Passenger"/>.
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s owned by this <see cref="Passenger"/>.
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}