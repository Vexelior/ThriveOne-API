using MediatR;
using Persistence;

namespace Application.Features.WorkTask.Read;

public class ReadWorkTaskHandler(ApplicationDbContext context) : IRequestHandler<ReadWorkTask, Persistence.Entities.WorkTask.WorkTask>
{
    public async Task<Persistence.Entities.WorkTask.WorkTask> Handle(ReadWorkTask request, CancellationToken cancellationToken)
    {
        var workTask = await context.WorkTasks.FindAsync([request.Id], cancellationToken);
        return workTask;
    }
}
