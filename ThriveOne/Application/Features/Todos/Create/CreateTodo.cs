using MediatR;

namespace Application.Features.Todos.Create;

public class CreateTodo : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Completed { get; set; } = null;
    public DateTime? Due { get; set; } = null;
    public bool IsCompleted { get; set; } = false;
}
