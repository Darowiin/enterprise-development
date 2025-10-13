using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class AirCraftFamilyService(IRepository<AircraftFamily, int> repository, IMapper mapper) : IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>
{
    public AircraftFamilyDto Create(AircraftFamilyCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftFamily>(dto);

        repository.Create(entity);

        return mapper.Map<AircraftFamilyDto>(entity);
    }

    public AircraftFamilyDto Get(int dtoId) => mapper.Map<AircraftFamilyDto>(repository.Get(dtoId));

    public List<AircraftFamilyDto> GetAll() => mapper.Map<List<AircraftFamilyDto>>(repository.GetAll());


    public AircraftFamilyDto Update(AircraftFamilyCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<AircraftFamilyDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);
}