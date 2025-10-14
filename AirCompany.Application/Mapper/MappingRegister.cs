namespace AirCompany.Application.Mapper;

/// <summary>
/// Global Mapster configuration for mapping between Domain and DTO models.
/// </summary>
public class MappingRegister : IRegister
{
    /// <summary>
    /// Registers mappings between domain models and DTOs.
    /// </summary>
    /// <param name="config">The TypeAdapterConfig instance used to define mapping rules.</param>
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Ticket, TicketDto>()
            .Map(dest => dest.FlightId, src => src.Flight.Id)
            .Map(dest => dest.PassengerId, src => src.Passenger.Id);

        config.NewConfig<TicketCreateUpdateDto, Ticket>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.Flight)
            .Ignore(dest => dest.Passenger);

        config.NewConfig<Passenger, PassengerDto>()
            .Map(dest => dest.TicketIds, src => src.Tickets!.Select(t => t.Id));

        config.NewConfig<PassengerCreateUpdateDto, Passenger>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.Tickets);

        config.NewConfig<Flight, FlightDto>()
            .Map(dest => dest.AircraftModelId, src => src.AircraftModel.Id)
            .Map(dest => dest.TicketIds, src => src.Tickets!.Select(t => t.Id));

        config.NewConfig<FlightCreateUpdateDto, Flight>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.AircraftModel)
            .Ignore(dest => dest.Tickets);

        config.NewConfig<AircraftModel, AircraftModelDto>()
            .Map(dest => dest.AircraftFamilyId, src => src.Family.Id)
            .Map(dest => dest.FlightIds, src => src.Flights!.Select(f => f.Id));

        config.NewConfig<AircraftModelCreateUpdateDto, AircraftModel>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.Family)
            .Ignore(dest => dest.Flights);

        config.NewConfig<AircraftFamily, AircraftFamilyDto>()
            .Map(dest => dest.AircraftModelIds, src => src.Models!.Select(m => m.Id));

        config.NewConfig<AircraftFamilyCreateUpdateDto, AircraftFamily>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.Models);
    }
}