using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.History;

public class ReadDebtHistoryHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtHistory, Persistence.Entities.Debt.History>
{
    public async Task<Persistence.Entities.Debt.History> Handle(ReadDebtHistory request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtHistories.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
