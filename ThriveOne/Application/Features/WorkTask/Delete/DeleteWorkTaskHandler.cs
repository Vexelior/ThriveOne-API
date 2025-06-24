using MediatR;
using Persistence;

namespace Application.Features.WorkTask.Delete;

public class DeleteWorkTaskHandler(ApplicationDbContext context) : IRequestHandler<DeleteWorkTask, Persistence.Entities.WorkTask.WorkTask>
{
    public async Task<Persistence.Entities.WorkTask.WorkTask> Handle(DeleteWorkTask request, CancellationToken cancellationToken)
    {
        var workTask = await context.WorkTasks.FindAsync([request.Id], cancellationToken);
        if (workTask == null)
        {
            throw new KeyNotFoundException($"WorkTask with ID {request.Id} not found.");
        }
        workTask.IsDeleted = true;
        context.WorkTasks.Update(workTask);
        await context.SaveChangesAsync(cancellationToken);
        return workTask;
    }
}
