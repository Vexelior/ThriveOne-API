using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Payment;

public class ReadDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPayment, List<Persistence.Entities.Debt.Payment>>
{
    public async Task<List<Persistence.Entities.Debt.Payment>> Handle(ReadDebtPayment request, CancellationToken cancellationToken)
    {
        var payments = await context.DebtPayments.Where(x => x.DebtId == request.Id).ToListAsync(cancellationToken);
        return payments;
    }
}
