using MediatR;
using Persistence;

namespace Application.Features.Todo.Read;

public class ReadTodosHandler(ApplicationDbContext context) : IRequestHandler<ReadTodos, List<Persistence.Entities.Todo.Todo>>
{
    public async Task<List<Persistence.Entities.Todo.Todo>> Handle(ReadTodos request, CancellationToken cancellationToken)
    {
        var todo = context.Todos.ToList();
        return todo;
    }
}
