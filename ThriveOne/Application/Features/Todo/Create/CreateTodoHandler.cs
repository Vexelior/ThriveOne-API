using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Todo.Create;

public class CreateTodoHandler(ApplicationDbContext context) : IRequestHandler<CreateTodo, Guid>
{
    public async Task<Guid> Handle(CreateTodo request, CancellationToken cancellationToken)
    {
        CreateTodoValidator validator = new CreateTodoValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var todo = new Persistence.Entities.Todo.Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Created = request.Created,
            Completed = request.Completed,
            Due = request.Due,
            IsCompleted = false
        };

        context.Todos.Add(todo);
        await context.SaveChangesAsync(cancellationToken);

        return todo.Id;
    }
}
