using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.PreviousPercentage;

public class UpdateDebtPreviousPercentageHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtPreviousPercentage, Persistence.Entities.Debt.PreviousPercentage>
{
    public async Task<Persistence.Entities.Debt.PreviousPercentage> Handle(UpdateDebtPreviousPercentage request, CancellationToken cancellationToken)
    {
        var previousPercentage = await context.DebtPreviousPercentages.FindAsync([request.Id], cancellationToken);
        if (previousPercentage == null)
        {
            throw new KeyNotFoundException($"Debt previous percentage with ID {request.Id} not found.");
        }
        previousPercentage.DebtId = request.DebtId;
        previousPercentage.Percent = request.Percent;
        previousPercentage.Date = request.Date;
        context.DebtPreviousPercentages.Update(previousPercentage);
        await context.SaveChangesAsync(cancellationToken);
        return previousPercentage;
    }
}
