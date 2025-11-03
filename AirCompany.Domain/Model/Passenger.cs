using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a passenger who can purchase <see cref="Ticket"/>s.
/// </summary>
[Table("passengers")]
public class Passenger
{
    /// <summary>
    /// Unique identifier of the passenger.
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Passport number of the passenger.
    /// </summary>
    [Column("passport_number")]
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Full name of the passenger.
    /// </summary>
    [Column("full_name")]
    public required string FullName { get; set; }

    /// <summary>
    /// Date of birth of the passenger.
    /// </summary>
    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s owned by this passenger.
    /// </summary>
    public virtual List<Ticket>? Tickets { get; set; } = [];
}