using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.InterestCharge;

public class CreateDebtInterestChargeHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtInterestCharge, Persistence.Entities.Debt.InterestCharge>
{
    public async Task<Persistence.Entities.Debt.InterestCharge> Handle(CreateDebtInterestCharge request, CancellationToken cancellationToken)
    {
        CreateDebtInterestChargeValidator validator = new CreateDebtInterestChargeValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var debtInterestCharge = new Persistence.Entities.Debt.InterestCharge
        {
            Id = Guid.NewGuid(),
            DebtId = request.DebtId,
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description
        };

        var debt = await context.Debts.FindAsync([request.DebtId], cancellationToken);
        if (debt == null)
        {
            throw new KeyNotFoundException($"Debt with ID {request.DebtId} not found.");
        }

        context.DebtPreviousPercentages.Add(new Persistence.Entities.Debt.PreviousPercentage
        {
            Percent = debt.PercentageChange,
            DebtId = request.DebtId,
            Date = DateTime.Now
        });

        debt.PreviousAmount = debt.RemainingAmount;
        debt.RemainingAmount += request.Amount;
        debt.PercentageChange = ((debt.RemainingAmount - debt.PreviousAmount) / debt.PreviousAmount) * 100;
        debt.DateEdited = DateTime.Now;

        context.DebtPreviousAmounts.Add(new Persistence.Entities.Debt.PreviousAmount
        {
            Amount = debt.PreviousAmount,
            PercentageChange = debt.PercentageChange,
            DebtId = request.DebtId,
            Description = "Interest Charge",
            DateAdded = DateTime.Now
        });

        context.Debts.Update(debt);
        context.DebtInterestCharges.Add(debtInterestCharge);
        await context.SaveChangesAsync(cancellationToken);
        return debtInterestCharge;
    }
}
