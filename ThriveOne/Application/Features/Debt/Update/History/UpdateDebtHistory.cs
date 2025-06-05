using MediatR;

namespace Application.Features.Debt.Update.History;

public class UpdateDebtHistory : IRequest<Persistence.Entities.Debt.History>
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public string Property { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Description { get; set; }
}
