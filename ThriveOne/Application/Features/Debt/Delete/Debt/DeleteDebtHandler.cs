using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.Debt;

public class DeleteDebtHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebt, Persistence.Entities.Debt.Debt>
{
    public async Task<Persistence.Entities.Debt.Debt> Handle(DeleteDebt request, CancellationToken cancellationToken)
    {
        var debt = await context.Debts.FindAsync([request.Id], cancellationToken);
        if (debt == null)
        {
            throw new KeyNotFoundException($"Debt with ID {request.Id} not found.");
        }
        context.Debts.Remove(debt);
        await context.SaveChangesAsync(cancellationToken);
        return debt;
    }
}
