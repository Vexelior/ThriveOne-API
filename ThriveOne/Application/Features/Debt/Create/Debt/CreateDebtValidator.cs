using FluentValidation;

namespace Application.Features.Debt.Create.Debt;

public class CreateDebtValidator : AbstractValidator<CreateDebt>
{
    public CreateDebtValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Creditor).NotEmpty();
        RuleFor(x => x.Notes).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Type).NotEmpty();
    }
}
