using MediatR;
using Persistence.Entities;

namespace Application.Features.Todos.Read;

public class ReadTodo(Guid id) : IRequest<Todo>
{
    public Guid Id { get; set; } = id;
}
