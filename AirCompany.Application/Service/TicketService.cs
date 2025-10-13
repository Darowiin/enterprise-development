using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class TicketService(IRepository<Ticket, int> repository, IMapper mapper) : IApplicationService<TicketDto, TicketCreateUpdateDto, int>
{
    public TicketDto Create(TicketCreateUpdateDto dto)
    {
        var entity = mapper.Map<Ticket>(dto);

        repository.Create(entity);

        return mapper.Map<TicketDto>(entity);
    }

    public TicketDto Get(int dtoId) => mapper.Map<TicketDto>(repository.Get(dtoId));

    public List<TicketDto> GetAll() => mapper.Map<List<TicketDto>>(repository.GetAll());


    public TicketDto Update(TicketCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<TicketDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);
}