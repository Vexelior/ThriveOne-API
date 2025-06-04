using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.PreviousPercentage;

public class ReadDebtPreviousPercentagesHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousPercentages, List<Persistence.Entities.Debt.PreviousPercentage>>
{
    public async Task<List<Persistence.Entities.Debt.PreviousPercentage>> Handle(ReadDebtPreviousPercentages request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtPreviousPercentages.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
