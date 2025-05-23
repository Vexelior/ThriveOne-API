using MediatR;

namespace Application.Features.Debt.Create.InterestCharge;

public class CreateDebtInterestCharge : IRequest<Persistence.Entities.Debt.InterestCharge>
{
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
