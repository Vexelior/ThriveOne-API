using Application.Features.Debt.Read.Debt;
using MediatR;
using Persistence;
namespace Application.Features.Debt.Update.Debt;

public class UpdateDebtHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebt, Persistence.Entities.Debt.Debt>
{
    public async Task<Persistence.Entities.Debt.Debt> Handle(UpdateDebt request, CancellationToken cancellationToken)
    {
        var debt = await context.Debts.FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken);
        if (debt == null)
        {
            throw new KeyNotFoundException("Debt not found");
        }
        debt.Creditor = request.Creditor;
        debt.Amount = request.Amount;
        debt.RemainingAmount = request.RemainingAmount;
        debt.PreviousAmount = request.PreviousAmount;
        debt.Notes = request.Notes;
        debt.DateAdded = request.DateAdded;
        debt.DateEdited = request.DateEdited;
        debt.PercentageChange = request.PercentageChange;
        debt.Type = request.Type;
        debt.Image = request.Image;
        debt.ImageId = request.ImageId;
        debt.ImageSource = request.ImageSource;
        debt.InterestRate = request.InterestRate;
        debt.LastPayment = request.LastPayment;
        debt.LastPaymentDate = request.LastPaymentDate;
        debt.MinimumPayment = request.MinimumPayment;
        context.Debts.Update(debt);
        await context.SaveChangesAsync(cancellationToken);
        return debt;
    }
}
