using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.History;

public class ReadDebtHistoriesHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtHistories, List<Persistence.Entities.Debt.History>>
{
    public async Task<List<Persistence.Entities.Debt.History>> Handle(ReadDebtHistories request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtHistories.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
