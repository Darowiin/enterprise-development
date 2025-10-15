namespace AirCompany.Application.Contracts.Passenger;

/// <summary>
/// DTO representing a passenger.
/// </summary>
/// <param name="Id">Unique identifier of the passenger.</param>
/// <param name="PassportNumber">Passport number of the passenger.</param>
/// <param name="FullName">Full name of the passenger.</param>
/// <param name="BirthDate">Date of birth of the passenger.</param>
public record PassengerDto(int Id, string PassportNumber, string FullName, DateOnly? BirthDate);