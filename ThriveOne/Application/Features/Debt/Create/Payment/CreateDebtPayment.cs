using MediatR;

namespace Application.Features.Debt.Create.Payment;

public class CreateDebtPayment : IRequest<Persistence.Entities.Debt.Payment>
{
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
}
