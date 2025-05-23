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
        context.DebtInterestCharges.Add(debtInterestCharge);
        await context.SaveChangesAsync(cancellationToken);
        return debtInterestCharge;
    }
}
