using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.Image;

public class CreateDebtImageHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtImage, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(CreateDebtImage request, CancellationToken cancellationToken)
    {
        CreateDebtImageValidator validator = new CreateDebtImageValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var debtImage = new Persistence.Entities.Debt.Image
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Source = request.Source,
            Uploaded = request.Uploaded
        };
        context.DebtImages.Add(debtImage);
        await context.SaveChangesAsync(cancellationToken);
        return debtImage;
    }
}
