using MediatR;

namespace Application.Features.Todo.Create;

public class CreateTodo : IRequest<Persistence.Entities.Todo.Todo>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Completed { get; set; } = null;
    public DateTime? Due { get; set; } = null;
    public bool IsCompleted { get; set; } = false;
    public string? TimeOfDay { get; set; } = null;
}
