using MediatR;
using Persistence;

namespace Application.Features.Todo.Delete;

public class DeleteTodoHandler(ApplicationDbContext context) : IRequestHandler<DeleteTodo, Persistence.Entities.Todo.Todo>
{
    public async Task<Persistence.Entities.Todo.Todo> Handle(DeleteTodo request, CancellationToken cancellationToken)
    {
        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        context.Todos.Remove(todo);
        await context.SaveChangesAsync(cancellationToken);
        return todo;
    }
}
