using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.Payment;

public class DeleteDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtPayment, Persistence.Entities.Debt.Payment>
{
    public async Task<Persistence.Entities.Debt.Payment> Handle(DeleteDebtPayment request, CancellationToken cancellationToken)
    {
        var payment = await context.DebtPayments.FindAsync([request.Id], cancellationToken);
        if (payment == null)
        {
            throw new KeyNotFoundException($"Debt payment with ID {request.Id} not found.");
        }
        context.DebtPayments.Remove(payment);
        await context.SaveChangesAsync(cancellationToken);
        return payment;
    }
}
