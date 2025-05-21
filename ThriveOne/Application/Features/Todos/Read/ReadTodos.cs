using MediatR;
using Persistence.Entities;

namespace Application.Features.Todos.Read;

public class ReadTodos : IRequest<List<Todo>>
{
}
