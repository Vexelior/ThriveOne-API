using MediatR;
using Persistence;

namespace Application.Features.WorkTask.Read;

public class ReadWorkTasksHandler(ApplicationDbContext context) : IRequestHandler<ReadWorkTasks, List<Persistence.Entities.WorkTask.WorkTask>>
{
    public async Task<List<Persistence.Entities.WorkTask.WorkTask>> Handle(ReadWorkTasks request, CancellationToken cancellationToken)
    {
        var workTasks = context.WorkTasks.ToList();
        return workTasks;
    }
}
