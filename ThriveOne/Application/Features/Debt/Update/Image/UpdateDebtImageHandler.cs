using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.Image;

public class UpdateDebtImageHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtImage, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(UpdateDebtImage request, CancellationToken cancellationToken)
    {
        var image = await context.DebtImages.FindAsync([request.Id], cancellationToken);
        if (image == null)
        {
            throw new KeyNotFoundException($"Debt image with ID {request.Id} not found.");
        }
        image.Name = request.Name;
        image.Source = request.Source;
        image.Uploaded = request.Uploaded;
        context.DebtImages.Update(image);
        await context.SaveChangesAsync(cancellationToken);
        return image;
    }
}
