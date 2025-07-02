using MediatR;

namespace Application.Features.Todo.Update;

public class UpdateTodo(Guid id, string title, string description, DateTime? created, DateTime? completed, DateTime? due, bool isCompleted, string timeOfDay) : IRequest<Persistence.Entities.Todo.Todo>
{
    public Guid Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime? Created { get; set; } = created;
    public DateTime? Completed { get; set; } = completed;
    public DateTime? Due { get; set; } = due;
    public bool IsCompleted { get; set; } = isCompleted;
    public string? TimeOfDay { get; set; } = timeOfDay;
}
