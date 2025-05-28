using MediatR;

namespace Application.Features.Debt.Create.PreviousPercentage;

public class CreateDebtPreviousPercentage : IRequest<Persistence.Entities.Debt.PreviousPercentage>
{
    public Guid DebtId { get; set; }
    public double Percent { get; set; }
    public DateTime Date { get; set; }
}
