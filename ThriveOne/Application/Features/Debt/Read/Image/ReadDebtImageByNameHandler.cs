using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImageByNameHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtImageByName, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(ReadDebtImageByName request, CancellationToken cancellationToken)
    {
        var debtImage = await context.DebtImages.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken: cancellationToken);
        return debtImage;
    }
}
