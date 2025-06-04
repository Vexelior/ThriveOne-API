using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.PreviousAmount;

public class ReadDebtPreviousAmountHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtPreviousAmount, Persistence.Entities.Debt.PreviousAmount>
{
    public async Task<Persistence.Entities.Debt.PreviousAmount> Handle(ReadDebtPreviousAmount request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtPreviousAmounts.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
