using MediatR;

namespace Application.Features.Todo.Read;

public class ReadTodo(Guid id) : IRequest<Persistence.Entities.Todo.Todo>
{
    public Guid Id { get; set; } = id;
}
