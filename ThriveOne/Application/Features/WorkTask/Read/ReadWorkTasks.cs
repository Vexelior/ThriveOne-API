using MediatR;

namespace Application.Features.WorkTask.Read;

public class ReadWorkTasks : IRequest<List<Persistence.Entities.WorkTask.WorkTask>>
{
}
