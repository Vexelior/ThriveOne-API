using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.Payment;

public class CreateDebtPaymentHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtPayment, Persistence.Entities.Debt.Payment>
{
    public async Task<Persistence.Entities.Debt.Payment> Handle(CreateDebtPayment request, CancellationToken cancellationToken)
    {
        CreateDebtPaymentValidator validator = new CreateDebtPaymentValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var debtPayment = new Persistence.Entities.Debt.Payment
        {
            Id = Guid.NewGuid(),
            DebtId = request.DebtId,
            Amount = request.Amount,
            Date = request.Date
        };
        var debt = await context.Debts.FindAsync([request.DebtId], cancellationToken);
        if (debt == null)
        {
            throw new KeyNotFoundException($"Debt with ID {request.DebtId} not found.");
        }

        debt.PreviousAmount = debt.RemainingAmount;
        debt.RemainingAmount -= request.Amount;
        debt.LastPayment = request.Amount;
        debt.LastPaymentDate = request.Date;
        debt.DateEdited = DateTime.Now;
        debt.PercentageChange = ((debt.RemainingAmount - debt.PreviousAmount) / debt.PreviousAmount) * 100;

        context.DebtPreviousAmounts.Add(new Persistence.Entities.Debt.PreviousAmount
        {
            Amount = debt.PreviousAmount,
            PercentageChange = debt.PercentageChange,
            DebtId = request.DebtId,
            Description = "Payment",
            DateAdded = DateTime.Now
        });
        context.Debts.Update(debt);
        context.DebtPayments.Add(debtPayment);
        await context.SaveChangesAsync(cancellationToken);
        return debtPayment;
    }
}
