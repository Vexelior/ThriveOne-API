using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Debt;

public class ReadDebtsHandler(ApplicationDbContext context) : IRequestHandler<ReadDebts, List<Persistence.Entities.Debt.Debt>>
{
    public async Task<List<Persistence.Entities.Debt.Debt>> Handle(ReadDebts request, CancellationToken cancellationToken)
    {
        var debts = await context.Debts.OrderByDescending(x => x.RemainingAmount).ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
