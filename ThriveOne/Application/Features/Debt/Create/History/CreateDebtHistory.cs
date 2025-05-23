using MediatR;

namespace Application.Features.Debt.Create.History;

public class CreateDebtHistory : IRequest<Persistence.Entities.Debt.History>
{
    public Guid DebtId { get; set; }
    public string Property { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Description { get; set; }
}
