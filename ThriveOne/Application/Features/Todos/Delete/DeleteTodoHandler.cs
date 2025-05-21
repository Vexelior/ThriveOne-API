using MediatR;
using Persistence.Entities;
using Persistence;

namespace Application.Features.Todos.Delete;

public class DeleteTodoHandler(ApplicationDbContext context) : IRequestHandler<DeleteTodo, Todo>
{
    public async Task<Todo> Handle(DeleteTodo request, CancellationToken cancellationToken)
    {
        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        context.Todos.Remove(todo);
        await context.SaveChangesAsync(cancellationToken);
        return todo;
    }
}
