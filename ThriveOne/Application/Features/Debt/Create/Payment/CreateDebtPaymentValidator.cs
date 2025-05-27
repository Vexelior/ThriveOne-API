using FluentValidation;

namespace Application.Features.Debt.Create.Payment;

public class CreateDebtPaymentValidator : AbstractValidator<CreateDebtPayment>
{
    public CreateDebtPaymentValidator()
    {
        RuleFor(x => x.DebtId).NotEmpty().WithMessage("DebtId is required.");
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
    }
}
