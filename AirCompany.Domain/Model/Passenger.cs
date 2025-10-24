namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a passenger who can purchase <see cref="Ticket"/>s.
/// </summary>
public class Passenger
{
    /// <summary>
    /// Unique identifier of the passenger.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Passport number of the passenger.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Full name of the passenger.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Date of birth of the passenger.
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s owned by this passenger.
    /// </summary>
    public virtual List<Ticket>? Tickets { get; set; } = [];
}