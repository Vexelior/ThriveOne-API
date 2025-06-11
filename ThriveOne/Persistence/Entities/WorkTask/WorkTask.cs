namespace Persistence.Entities.WorkTask;

public class WorkTask
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CompletedAt { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string Markdown { get; set; }
    public string HTML { get; set; }
    public bool IsCompleted { get; set; }
}
