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
        context.DebtPayments.Add(debtPayment);
        await context.SaveChangesAsync(cancellationToken);
        return debtPayment;
    }
}
