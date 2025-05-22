using MediatR;

namespace Application.Features.Todo.Read;

public class ReadTodos : IRequest<List<Persistence.Entities.Todo.Todo>>
{
}
