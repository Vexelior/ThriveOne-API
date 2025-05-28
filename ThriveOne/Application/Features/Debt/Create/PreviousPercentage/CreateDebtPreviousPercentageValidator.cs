using FluentValidation;

namespace Application.Features.Debt.Create.PreviousPercentage;

public class CreateDebtPreviousPercentageValidator : AbstractValidator<CreateDebtPreviousPercentage>
{
    public CreateDebtPreviousPercentageValidator()
    {
        RuleFor(x => x.Percent).NotEmpty()
                                                       .WithMessage("Percentage is required.")
                                                       .InclusiveBetween(0, 100)
                                                       .WithMessage("Percentage must be between 0 and 100.");
        RuleFor(x => x.DebtId).NotEmpty().WithMessage("Debt ID is required.");
        RuleFor(x => x.Date).NotEmpty()
                                                    .WithMessage("Date is required.")
                                                    .LessThanOrEqualTo(DateTime.UtcNow)
                                                    .WithMessage("Date cannot be in the future.");
    }
}
