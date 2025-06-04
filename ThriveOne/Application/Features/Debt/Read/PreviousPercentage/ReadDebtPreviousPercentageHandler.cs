using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.PreviousPercentage;

public class ReadDebtPreviousPercentageHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousPercentage, Persistence.Entities.Debt.PreviousPercentage>
{
    public async Task<Persistence.Entities.Debt.PreviousPercentage> Handle(ReadDebtPreviousPercentage request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtPreviousPercentages.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
