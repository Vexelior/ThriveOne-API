using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImagesHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtImages, List<Persistence.Entities.Debt.Image>>
{
    public async Task<List<Persistence.Entities.Debt.Image>> Handle(ReadDebtImages request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtImages.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
