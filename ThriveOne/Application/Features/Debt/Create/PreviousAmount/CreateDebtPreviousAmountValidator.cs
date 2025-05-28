using FluentValidation;

namespace Application.Features.Debt.Create.PreviousAmount;

public class CreateDebtPreviousAmountValidator : AbstractValidator<CreateDebtPreviousAmount>
{
    public CreateDebtPreviousAmountValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required.");
        RuleFor(x => x.PercentageChange).NotEmpty()
                                                            .WithMessage("Percentage change is required.")
                                                            .GreaterThanOrEqualTo(-100)
                                                            .WithMessage("Percentage change must be greater than or equal to -100%.");
        RuleFor(x => x.DebtId).NotEmpty().WithMessage("Debt ID is required.");
        RuleFor(x => x.Description).NotEmpty()
                                                       .WithMessage("Description is required.")
                                                       .MaximumLength(500)
                                                       .WithMessage("Description cannot exceed 500 characters.");
        RuleFor(x => x.DateAdded).NotEmpty().WithMessage("Date added is required.");
    }
}
