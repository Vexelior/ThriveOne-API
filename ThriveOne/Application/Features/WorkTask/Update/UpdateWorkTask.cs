using MediatR;

namespace Application.Features.WorkTask.Update;

public class UpdateWorkTask(Guid id, string title, string description, DateTime completedAt, DateTime dueDate, string priority, string status, string markdown, string html, bool isCompleted) : IRequest<Persistence.Entities.WorkTask.WorkTask>
{
    public Guid Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime CompletedAt { get; set; } = completedAt;
    public DateTime DueDate { get; set; } = dueDate;
    public string Priority { get; set; } = priority;
    public string Status { get; set; } = status;
    public string Markdown { get; set; } = markdown;
    public string HTML { get; set; } = html;
    public bool IsCompleted { get; set; } = isCompleted;

}
