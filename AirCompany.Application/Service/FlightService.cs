using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class FlightService(IRepository<Flight, int> repository, IMapper mapper) : IApplicationService<FlightDto, FlightCreateUpdateDto, int>
{
    public FlightDto Create(FlightCreateUpdateDto dto)
    {
        var entity = mapper.Map<Flight>(dto);

        repository.Create(entity);

        return mapper.Map<FlightDto>(entity);
    }

    public FlightDto Get(int dtoId) => mapper.Map<FlightDto>(repository.Get(dtoId));

    public List<FlightDto> GetAll() => mapper.Map<List<FlightDto>>(repository.GetAll());


    public FlightDto Update(FlightCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<FlightDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);
}