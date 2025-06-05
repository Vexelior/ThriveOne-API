using MediatR;

namespace Application.Features.WorkTask.Read;

public class ReadWorkTask(Guid id) : IRequest<Persistence.Entities.WorkTask.WorkTask>
{
    public Guid Id { get; set; } = id;
}
