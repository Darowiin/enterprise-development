using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class PassengerService(IRepository<Passenger, int> repository, IMapper mapper) : IApplicationService<PassengerDto, PassengerCreateUpdateDto, int>
{
    public PassengerDto Create(PassengerCreateUpdateDto dto)
    {
        var entity = mapper.Map<Passenger>(dto);

        repository.Create(entity);

        return mapper.Map<PassengerDto>(entity);
    }

    public PassengerDto Get(int dtoId) => mapper.Map<PassengerDto>(repository.Get(dtoId));

    public List<PassengerDto> GetAll() => mapper.Map<List<PassengerDto>>(repository.GetAll());


    public PassengerDto Update(PassengerCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<PassengerDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);
}