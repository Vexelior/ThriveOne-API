using MediatR;

namespace Application.Features.Debt.Update.PreviousPercentage;

public class UpdateDebtPreviousPercentage : IRequest<Persistence.Entities.Debt.PreviousPercentage>
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Percent { get; set; }
    public DateTime Date { get; set; }
}
