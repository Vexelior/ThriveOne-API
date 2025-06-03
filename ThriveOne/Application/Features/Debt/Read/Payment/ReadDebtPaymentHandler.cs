using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.Payment;

public class ReadDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPayment, Persistence.Entities.Debt.Payment>
{
    public async Task<Persistence.Entities.Debt.Payment> Handle(ReadDebtPayment request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtPayments.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
