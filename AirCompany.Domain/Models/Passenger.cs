namespace AirCompany.Domain.Models;

/// <summary>
/// Represents a passenger.
/// </summary>
public class Passenger
{
    /// <summary>
    /// Unique identifier of the passenger.
    /// </summary>
    public int Id { get; set; }

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
    /// Navigation property: tickets owned by this passenger.
    /// </summary>
    public List<Ticket> Tickets { get; set; } = [];
}