using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.PreviousAmount;

public class DeleteDebtPreviousAmountHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtPreviousAmount, Persistence.Entities.Debt.PreviousAmount>
{
    public async Task<Persistence.Entities.Debt.PreviousAmount> Handle(DeleteDebtPreviousAmount request, CancellationToken cancellationToken)
    {
        var previousAmount = await context.DebtPreviousAmounts.FindAsync([request.Id], cancellationToken);
        if (previousAmount == null)
        {
            throw new KeyNotFoundException($"Debt previous amount charge with ID {request.Id} not found.");
        }
        context.DebtPreviousAmounts.Remove(previousAmount);
        await context.SaveChangesAsync(cancellationToken);
        return previousAmount;
    }
}
