using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImageHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtImage, Persistence.Entities.Debt.Image>
{
    public async Task<Persistence.Entities.Debt.Image> Handle(ReadDebtImage request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtImages.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
