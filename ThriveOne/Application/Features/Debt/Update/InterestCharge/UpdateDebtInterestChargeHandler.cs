using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.InterestCharge;

public class UpdateDebtInterestChargeHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtInterestCharge, Persistence.Entities.Debt.InterestCharge>
{
    public async Task<Persistence.Entities.Debt.InterestCharge> Handle(UpdateDebtInterestCharge request, CancellationToken cancellationToken)
    {
        var interestCharge = await context.DebtInterestCharges.FindAsync([request.Id], cancellationToken);
        if (interestCharge == null)
        {
            throw new KeyNotFoundException($"Debt interest charge with ID {request.Id} not found.");
        }
        interestCharge.DebtId = request.DebtId;
        interestCharge.Amount = request.Amount;
        interestCharge.Date = request.Date;
        interestCharge.Description = request.Description;
        context.DebtInterestCharges.Update(interestCharge);
        await context.SaveChangesAsync(cancellationToken);
        return interestCharge;
    }
}
