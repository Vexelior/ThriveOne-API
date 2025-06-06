using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.History;

public class ReadDebtHistoryHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtHistory, List<Persistence.Entities.Debt.History>>
{
    public async Task<List<Persistence.Entities.Debt.History>> Handle(ReadDebtHistory request, CancellationToken cancellationToken)
    {
        var history = await context.DebtHistories.Where(x => x.DebtId == request.Id).ToListAsync(cancellationToken);
        return history;
    }
}
