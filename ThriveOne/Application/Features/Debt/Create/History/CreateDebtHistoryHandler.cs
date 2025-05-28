using MediatR;
using Persistence;

namespace Application.Features.Debt.Create.History;

public class CreateDebtHistoryHandler(ApplicationDbContext context) : IRequestHandler<CreateDebtHistory, Persistence.Entities.Debt.History>
{
    public async Task<Persistence.Entities.Debt.History> Handle(CreateDebtHistory request, CancellationToken cancellationToken)
    {
        CreateDebtHistoryValidator validationRules = new CreateDebtHistoryValidator();
        var validationResult = await validationRules.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new Exception(validationResult.Errors.First().ErrorMessage);
        }

        var debtHistory = new Persistence.Entities.Debt.History
        {
            DebtId = request.DebtId,
            Property = request.Property,
            OldValue = request.OldValue,
            NewValue = request.NewValue,
            Timestamp = request.Timestamp,
            Description = request.Description
        };
        context.DebtHistories.Add(debtHistory);
        await context.SaveChangesAsync(cancellationToken);
        return debtHistory;
    }
}
