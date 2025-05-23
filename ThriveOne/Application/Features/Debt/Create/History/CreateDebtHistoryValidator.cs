using FluentValidation;


namespace Application.Features.Debt.Create.History;

public class CreateDebtHistoryValidator : AbstractValidator<CreateDebtHistory>
{
    public CreateDebtHistoryValidator()
    {
        RuleFor(x => x.DebtId)
            .NotEmpty()
            .WithMessage("DebtId is required.");
        RuleFor(x => x.Property)
            .NotEmpty()
            .WithMessage("Property is required.");
        RuleFor(x => x.OldValue)
            .NotEmpty()
            .WithMessage("OldValue is required.");
        RuleFor(x => x.NewValue)
            .NotEmpty()
            .WithMessage("NewValue is required.");
        RuleFor(x => x.Timestamp)
            .NotEmpty()
            .WithMessage("Timestamp is required.");
    }
}
