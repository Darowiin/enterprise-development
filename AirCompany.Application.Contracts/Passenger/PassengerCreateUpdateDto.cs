namespace AirCompany.Application.Contracts.Passenger;

/// <summary>
/// DTO used for creating or updating passenger data.
/// </summary>
/// <param name="PassportNumber">Passport number of the passenger.</param>
/// <param name="FullName">Full name of the passenger.</param>
/// <param name="BirthDate">Date of birth of the passenger.</param>
public record PassengerCreateUpdateDto(string PassportNumber, string FullName, DateOnly? BirthDate);