using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.InterestCharge;

public class ReadDebtInterestChargesHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtInterestCharges, List<Persistence.Entities.Debt.InterestCharge>>
{
    public async Task<List<Persistence.Entities.Debt.InterestCharge>> Handle(ReadDebtInterestCharges request, CancellationToken cancellationToken)
    {
        var debts = await context.DebtInterestCharges.ToListAsync(cancellationToken: cancellationToken);
        return debts;
    }
}
