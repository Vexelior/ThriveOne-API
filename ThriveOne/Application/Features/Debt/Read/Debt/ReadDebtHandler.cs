using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.Debt;

public class ReadDebtHandler(ApplicationDbContext context) : IRequestHandler<ReadDebt, Persistence.Entities.Debt.Debt>
{
    public async Task<Persistence.Entities.Debt.Debt> Handle(ReadDebt request, CancellationToken cancellationToken)
    {
        var debt = await context.Debts.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
