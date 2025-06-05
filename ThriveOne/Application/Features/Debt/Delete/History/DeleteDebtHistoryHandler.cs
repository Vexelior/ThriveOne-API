using MediatR;
using Persistence;

namespace Application.Features.Debt.Delete.History;

public class DeleteDebtHistoryHandler(ApplicationDbContext context) : IRequestHandler<DeleteDebtHistory, Persistence.Entities.Debt.History>
{
    public async Task<Persistence.Entities.Debt.History> Handle(DeleteDebtHistory request, CancellationToken cancellationToken)
    {
        var history = await context.DebtHistories.FindAsync([request.Id], cancellationToken);
        if (history == null)
        {
            throw new KeyNotFoundException($"Debt history with ID {request.Id} not found.");
        }
        context.DebtHistories.Remove(history);
        await context.SaveChangesAsync(cancellationToken);
        return history;
    }
}
