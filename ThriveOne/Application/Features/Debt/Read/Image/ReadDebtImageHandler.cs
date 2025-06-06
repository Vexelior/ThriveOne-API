using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImageHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtImage, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(ReadDebtImage request, CancellationToken cancellationToken)
    {
        var image = await context.DebtImages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return image;
    }
}
