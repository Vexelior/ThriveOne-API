using MediatR;
using Persistence;

namespace Application.Features.Todo.Read;

public class ReadTodoHandler(ApplicationDbContext context) : IRequestHandler<ReadTodo, Persistence.Entities.Todo.Todo>
{
    public async Task<Persistence.Entities.Todo.Todo?> Handle(ReadTodo request, CancellationToken cancellationToken)
    {
        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        return todo;
    }
}
