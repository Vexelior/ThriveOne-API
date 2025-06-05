using FluentValidation.Results;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.Features.WorkTask.Update;

public class UpdateWorkTaskHandler(ApplicationDbContext context) : IRequestHandler<UpdateWorkTask, Persistence.Entities.WorkTask.WorkTask>
{
    public async Task<Persistence.Entities.WorkTask.WorkTask> Handle(UpdateWorkTask request, CancellationToken cancellationToken)
    {
        UpdateWorkTaskValidator validator = new UpdateWorkTaskValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var workTask = await context.WorkTasks.FindAsync([request.Id], cancellationToken);
        if (workTask == null)
        {
            throw new KeyNotFoundException($"Work task with ID {request.Id} not found.");
        }
        workTask.Title = request.Title;
        workTask.Description = request.Description;
        workTask.CompletedAt = request.CompletedAt;
        workTask.DueDate = request.DueDate;
        workTask.Priority = request.Priority;
        workTask.Status = request.Status;
        workTask.Markdown = request.Markdown;
        workTask.HTML = request.HTML;
        await context.SaveChangesAsync(cancellationToken);
        return workTask;
    }
}
