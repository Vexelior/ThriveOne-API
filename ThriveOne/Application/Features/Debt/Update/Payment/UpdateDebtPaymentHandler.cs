using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.Payment;

public class UpdateDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtPayment, Persistence.Entities.Debt.Payment>
{
    public async Task<Persistence.Entities.Debt.Payment> Handle(UpdateDebtPayment request, CancellationToken cancellationToken)
    {
        var payment = await context.DebtPayments.FindAsync([request.Id], cancellationToken);
        if (payment == null)
        {
            throw new KeyNotFoundException($"Debt payment with ID {request.Id} not found.");
        }
        payment.DebtId = request.DebtId;
        payment.Amount = request.Amount;
        payment.Date = request.Date;
        context.DebtPayments.Update(payment);
        await context.SaveChangesAsync(cancellationToken);
        return payment;
    }
}
