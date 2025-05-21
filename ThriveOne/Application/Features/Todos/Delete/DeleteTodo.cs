using MediatR;
using Persistence.Entities;

namespace Application.Features.Todos.Delete;

public class DeleteTodo(Guid id) : IRequest<Todo>
{
    public Guid Id { get; set; } = id;
}
