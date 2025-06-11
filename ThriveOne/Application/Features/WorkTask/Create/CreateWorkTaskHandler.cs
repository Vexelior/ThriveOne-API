using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.WorkTask.Create;

public class CreateWorkTaskHandler(ApplicationDbContext context) : IRequestHandler<CreateWorkTask, Persistence.Entities.WorkTask.WorkTask>
{
    public async Task<Persistence.Entities.WorkTask.WorkTask> Handle(CreateWorkTask request, CancellationToken cancellationToken)
    {
        CreateWorkTaskValidator validator = new CreateWorkTaskValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var workTask = new Persistence.Entities.WorkTask.WorkTask
        {
            Title = request.Title,
            Description = request.Description,
            CompletedAt = request.CompletedAt,
            DueDate = request.DueDate,
            Priority = request.Priority,
            Status = request.Status,
            Markdown = request.Markdown,
            HTML = request.HTML,
            IsCompleted = request.IsCompleted
        };

        context.WorkTasks.Add(workTask);
        await context.SaveChangesAsync(cancellationToken);

        return workTask;
    }
}
