using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.InterestCharge;

public class DeleteDebtInterestChargeHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtInterestCharge, Persistence.Entities.Debt.InterestCharge>
{
    public async Task<Persistence.Entities.Debt.InterestCharge> Handle(DeleteDebtInterestCharge request, CancellationToken cancellationToken)
    {
        var interestCharge = await context.DebtInterestCharges.FindAsync([request.Id], cancellationToken);
        if (interestCharge == null)
        {
            throw new KeyNotFoundException($"Debt interest charge with ID {request.Id} not found.");
        }
        context.DebtInterestCharges.Remove(interestCharge);
        await context.SaveChangesAsync(cancellationToken);
        return interestCharge;
    }
}
