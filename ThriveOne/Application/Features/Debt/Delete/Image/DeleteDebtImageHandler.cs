using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.Image;

public class DeleteDebtImageHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtImage, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(DeleteDebtImage request, CancellationToken cancellationToken)
    {
        var image = await context.DebtImages.FindAsync([request.Id], cancellationToken);
        if (image == null)
        {
            throw new KeyNotFoundException($"Debt image with ID {request.Id} not found.");
        }
        context.DebtImages.Remove(image);
        await context.SaveChangesAsync(cancellationToken);
        return image;
    }
}
