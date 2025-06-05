using MediatR;

namespace Application.Features.Debt.Update.Payment;

public class UpdateDebtPayment : IRequest<Persistence.Entities.Debt.Payment>
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
}
