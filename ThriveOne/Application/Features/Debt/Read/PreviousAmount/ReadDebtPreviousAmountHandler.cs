using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.PreviousAmount;

public class ReadDebtPreviousAmountHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousAmount, List<Persistence.Entities.Debt.PreviousAmount>>
{
    public async Task<List<Persistence.Entities.Debt.PreviousAmount>> Handle(ReadDebtPreviousAmount request, CancellationToken cancellationToken)
    {
        var previousAmounts = await context.DebtPreviousAmounts.Where(x => x.DebtId == request.Id).ToListAsync(cancellationToken);
        return previousAmounts;
    }
}
