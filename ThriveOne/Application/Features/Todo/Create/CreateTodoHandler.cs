using MediatR;
using Persistence;

namespace Application.Features.Todo.Create;

public class CreateTodoHandler(ApplicationDbContext context) : IRequestHandler<CreateTodo, Guid>
{
    public async Task<Guid> Handle(CreateTodo request, CancellationToken cancellationToken)
    {
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
