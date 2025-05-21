using MediatR;
using Persistence;
using Persistence.Entities;

namespace Application.Features.Todos.Read;

public class ReadTodosHandler(ApplicationDbContext context) : IRequestHandler<ReadTodos, List<Todo>>
{
    public async Task<List<Todo>> Handle(ReadTodos request, CancellationToken cancellationToken)
    {
        var todo = context.Todos.ToList();
        return todo;
    }
}
