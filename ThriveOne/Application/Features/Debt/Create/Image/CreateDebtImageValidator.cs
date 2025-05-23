using FluentValidation;

namespace Application.Features.Debt.Create.Image;

public class CreateDebtImageValidator : AbstractValidator<CreateDebtImage>
{
    public CreateDebtImageValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Source).NotEmpty().WithMessage("Source is required.");
        RuleFor(x => x.Uploaded).NotEmpty().WithMessage("Uploaded date is required.");
    }
}
