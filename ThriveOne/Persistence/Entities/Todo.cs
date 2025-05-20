namespace Persistence.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Completed { get; set; }
    public DateTime? Due { get; set; }
    public bool IsCompleted { get; set; }
}
