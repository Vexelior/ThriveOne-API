using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.PreviousAmount;

public class ReadDebtPreviousAmountsHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousAmounts, List<Persistence.Entities.Debt.PreviousAmount>>
{
    public async Task<List<Persistence.Entities.Debt.PreviousAmount>> Handle(ReadDebtPreviousAmounts request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtPreviousAmounts.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
