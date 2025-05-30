using MediatR;
using Persistence;

namespace Application.Features.Debt.Read.InterestCharge;

public class ReadDebtInterestChargeHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtInterestCharge, Persistence.Entities.Debt.InterestCharge>
{
    public async Task<Persistence.Entities.Debt.InterestCharge> Handle(ReadDebtInterestCharge request, CancellationToken cancellationToken)
    {
        var debt = await context.DebtInterestCharges.FindAsync([request.Id], cancellationToken);
        return debt;
    }
}
