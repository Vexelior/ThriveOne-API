using MediatR;

namespace Application.Features.Debt.Update.InterestCharge;

public class UpdateDebtInterestCharge : IRequest<Persistence.Entities.Debt.InterestCharge>
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
