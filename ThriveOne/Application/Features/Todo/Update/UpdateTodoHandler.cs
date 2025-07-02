using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Todo.Update;

public class UpdateTodoHandler(ApplicationDbContext context) : IRequestHandler<UpdateTodo, Persistence.Entities.Todo.Todo>
{
    public async Task<Persistence.Entities.Todo.Todo?> Handle(UpdateTodo request, CancellationToken cancellationToken)
    {
        UpdateTodoValidator validator = new UpdateTodoValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        if (todo == null)
        {
            return null;
        }
        todo.Title = request.Title;
        todo.Description = request.Description;
        todo.Created = request.Created ?? todo.Created;
        todo.Completed = request.Completed ?? todo.Completed;
        todo.Due = request.Due ?? todo.Due;
        todo.IsCompleted = request.IsCompleted;
        todo.TimeOfDay = request.TimeOfDay ?? string.Empty;
        await context.SaveChangesAsync(cancellationToken);
        return todo;
    }
}
