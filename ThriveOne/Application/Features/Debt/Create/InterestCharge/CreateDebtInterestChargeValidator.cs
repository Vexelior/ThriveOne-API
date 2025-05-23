using FluentValidation;

namespace Application.Features.Debt.Create.InterestCharge;

public class CreateDebtInterestChargeValidator : AbstractValidator<CreateDebtInterestCharge>
{
    public CreateDebtInterestChargeValidator()
    {
        RuleFor(x => x.DebtId).NotEmpty().WithMessage("DebtId is required.");
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
    }
}
