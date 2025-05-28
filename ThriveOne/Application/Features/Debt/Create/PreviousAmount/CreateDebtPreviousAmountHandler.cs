using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.PreviousAmount;

public class CreateDebtPreviousAmountHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtPreviousAmount, Persistence.Entities.Debt.PreviousAmount>
{
    public async Task<Persistence.Entities.Debt.PreviousAmount> Handle(CreateDebtPreviousAmount request, CancellationToken cancellationToken)
    {
        // Validate the request
        CreateDebtPreviousAmountValidator validator = new CreateDebtPreviousAmountValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var previousAmount = new Persistence.Entities.Debt.PreviousAmount
        {
            Amount = request.Amount,
            PercentageChange = request.PercentageChange,
            DebtId = request.DebtId,
            Description = request.Description,
            DateAdded = DateTime.UtcNow
        };
        context.DebtPreviousAmounts.Add(previousAmount);
        await context.SaveChangesAsync(cancellationToken);
        return previousAmount;
    }
}
