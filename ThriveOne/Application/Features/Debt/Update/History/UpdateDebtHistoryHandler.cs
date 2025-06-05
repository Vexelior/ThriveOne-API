using MediatR;
using Persistence;

namespace Application.Features.Debt.Update.History;

public class UpdateDebtHistoryHandler(ApplicationDbContext context) : IRequestHandler<UpdateDebtHistory, Persistence.Entities.Debt.History>
{
    public async Task<Persistence.Entities.Debt.History> Handle(UpdateDebtHistory request, CancellationToken cancellationToken)
    {
        var history = await context.DebtHistories.FindAsync([request.Id], cancellationToken);
        if (history == null)
        {
            throw new KeyNotFoundException($"Debt history with ID {request.Id} not found.");
        }
        history.DebtId = request.DebtId;
        history.Property = request.Property;
        history.OldValue = request.OldValue;
        history.NewValue = request.NewValue;
        history.Timestamp = request.Timestamp;
        history.Description = request.Description;
        context.DebtHistories.Update(history);
        await context.SaveChangesAsync(cancellationToken);
        return history;
    }
}
