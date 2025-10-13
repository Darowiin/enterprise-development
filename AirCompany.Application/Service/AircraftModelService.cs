using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class AirCraftModelService(IRepository<AircraftModel, int> repository, IMapper mapper) : IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int>
{
    public AircraftModelDto Create(AircraftModelCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftModel>(dto);

        repository.Create(entity);

        return mapper.Map<AircraftModelDto>(entity);
    }

    public AircraftModelDto Get(int dtoId) => mapper.Map<AircraftModelDto>(repository.Get(dtoId));

    public List<AircraftModelDto> GetAll() => mapper.Map<List<AircraftModelDto>>(repository.GetAll());


    public AircraftModelDto Update(AircraftModelCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<AircraftModelDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);
}