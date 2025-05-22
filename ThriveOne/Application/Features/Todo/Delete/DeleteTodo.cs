using MediatR;

namespace Application.Features.Todo.Delete;

public class DeleteTodo(Guid id) : IRequest<Persistence.Entities.Todo.Todo>
{
    public Guid Id { get; set; } = id;
}
