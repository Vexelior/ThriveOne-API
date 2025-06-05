using MediatR;

namespace Application.Features.WorkTask.Create;

public class CreateWorkTask : IRequest<Persistence.Entities.WorkTask.WorkTask>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CompletedAt { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string Markdown { get; set; }
    public string HTML { get; set; }
}
