using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.PreviousAmount;

public class UpdateDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtPreviousAmount, Persistence.Entities.Debt.PreviousAmount>
{
    public async Task<Persistence.Entities.Debt.PreviousAmount> Handle(UpdateDebtPreviousAmount request, CancellationToken cancellationToken)
    {
        var previousAmount = await context.DebtPreviousAmounts.FindAsync([request.Id], cancellationToken);
        if (previousAmount == null)
        {
            throw new KeyNotFoundException($"Debt previous amount with ID {request.Id} not found.");
        }
        previousAmount.Amount = request.Amount;
        previousAmount.PercentageChange = request.PercentageChange;
        previousAmount.DebtId = request.DebtId;
        previousAmount.Description = request.Description;
        previousAmount.DateAdded = request.DateAdded;
        context.DebtPreviousAmounts.Update(previousAmount);
        await context.SaveChangesAsync(cancellationToken);
        return previousAmount;
    }
}
