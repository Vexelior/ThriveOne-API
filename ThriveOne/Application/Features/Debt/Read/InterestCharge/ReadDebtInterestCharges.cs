using MediatR;

namespace Application.Features.Debt.Read.InterestCharge;

public class ReadDebtInterestCharges : IRequest<List<Persistence.Entities.Debt.InterestCharge>>
{
}
