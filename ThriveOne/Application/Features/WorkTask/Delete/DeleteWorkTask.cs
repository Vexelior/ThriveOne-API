using MediatR;

namespace Application.Features.WorkTask.Delete;

public class DeleteWorkTask(Guid id) : IRequest<Persistence.Entities.WorkTask.WorkTask>
{
    public Guid Id { get; set; } = id;
}
