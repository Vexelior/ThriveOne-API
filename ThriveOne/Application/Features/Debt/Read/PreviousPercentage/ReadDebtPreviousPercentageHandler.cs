using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.PreviousPercentage;

public class ReadDebtPreviousPercentageHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousPercentage, List<Persistence.Entities.Debt.PreviousPercentage>>
{
    public async Task<List<Persistence.Entities.Debt.PreviousPercentage>> Handle(ReadDebtPreviousPercentage request, CancellationToken cancellationToken)
    {
        var previousPercentages = await context.DebtPreviousPercentages.Where(x => x.DebtId == request.Id).ToListAsync(cancellationToken);
        return previousPercentages;
    }
}
