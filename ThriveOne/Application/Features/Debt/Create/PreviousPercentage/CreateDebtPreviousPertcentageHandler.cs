using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.PreviousPercentage;

public class CreateDebtPreviousPercentageHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtPreviousPercentage, Persistence.Entities.Debt.PreviousPercentage>
{
    public async Task<Persistence.Entities.Debt.PreviousPercentage> Handle(CreateDebtPreviousPercentage request, CancellationToken cancellationToken)
    {
        CreateDebtPreviousPercentageValidator validator = new CreateDebtPreviousPercentageValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var previousPercentage = new Persistence.Entities.Debt.PreviousPercentage
        {
            Percent = request.Percent,
            DebtId = request.DebtId,
            Date = request.Date
        };
        context.DebtPreviousPercentages.Add(previousPercentage);
        await context.SaveChangesAsync(cancellationToken);
        return previousPercentage;
    }
}
