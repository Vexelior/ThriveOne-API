using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.PreviousPercentage;

public class DeleteDebtPreviousPercentageHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtPreviousPercentage, Persistence.Entities.Debt.PreviousPercentage>
{
    public async Task<Persistence.Entities.Debt.PreviousPercentage> Handle(DeleteDebtPreviousPercentage request, CancellationToken cancellationToken)
    {
        var previousPercentage = await context.DebtPreviousPercentages.FindAsync([request.Id], cancellationToken);
        if (previousPercentage == null)
        {
            throw new KeyNotFoundException($"Debt previous amount charge with ID {request.Id} not found.");
        }
        context.DebtPreviousPercentages.Remove(previousPercentage);
        await context.SaveChangesAsync(cancellationToken);
        return previousPercentage;
    }
}
