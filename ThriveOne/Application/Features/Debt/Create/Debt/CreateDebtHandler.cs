using MediatR;
using Persistence;


namespace Application.Features.Debt.Create.Debt;

public class CreateDebtHandler(ApplicationDbContext context) : IRequestHandler<CreateDebt, Guid>
{
    public async Task<Guid> Handle(CreateDebt request, CancellationToken cancellationToken)
    {
        var debt = new Persistence.Entities.Debt.Debt
        {
            Id = Guid.NewGuid(),
            Creditor = request.Creditor,
            Amount = request.Amount,
            RemainingAmount = request.RemainingAmount,
            PreviousAmount = request.PreviousAmount,
            Notes = request.Notes,
            DateAdded = request.DateAdded,
            DateEdited = request.DateEdited,
            PercentageChange = request.PercentageChange,
            Type = request.Type,
            Image = request.Image,
            ImageId = request.ImageId,
            ImageSource = request.ImageSource,
            InterestRate = request.InterestRate,
            LastPayment = request.LastPayment,
            LastPaymentDate = request.LastPaymentDate,
            MinimumPayment = request.MinimumPayment
        };
        context.Debts.Add(debt);
        await context.SaveChangesAsync(cancellationToken);
        return debt.Id;
    }
}
