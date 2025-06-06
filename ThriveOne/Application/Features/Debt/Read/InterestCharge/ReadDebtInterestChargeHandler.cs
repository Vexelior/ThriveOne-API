using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Debt.Read.InterestCharge;

public class ReadDebtInterestChargeHandler(ApplicationDbContext context) : IRequestHandler<ReadDebtInterestCharge, List<Persistence.Entities.Debt.InterestCharge>>
{
    public async Task<List<Persistence.Entities.Debt.InterestCharge>> Handle(ReadDebtInterestCharge request, CancellationToken cancellationToken)
    {
        var interestCharges = await context.DebtInterestCharges.Where(x => x.DebtId == request.Id).ToListAsync(cancellationToken: cancellationToken);
        return interestCharges;
    }
}
