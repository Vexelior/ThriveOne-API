using MediatR;
using Persistence;
using Persistence.Entities;

namespace Application.Features.Todos.Read;

public class ReadTodoHandler(ApplicationDbContext context) : IRequestHandler<ReadTodo, Todo?>
{
    public async Task<Todo?> Handle(ReadTodo request, CancellationToken cancellationToken)
    {
        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        return todo;
    }
}
