using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Payment;

public class ReadDebtPaymentsHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPayments, List<Persistence.Entities.Debt.Payment>>
{
    public async Task<List<Persistence.Entities.Debt.Payment>> Handle(ReadDebtPayments request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtPayments.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
