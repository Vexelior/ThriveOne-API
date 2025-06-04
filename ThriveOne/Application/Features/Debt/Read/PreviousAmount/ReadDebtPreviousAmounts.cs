using MediatR;

namespace Application.Features.Debt.Read.PreviousAmount;

public class ReadDebtPreviousAmounts : IRequest<List<Persistence.Entities.Debt.PreviousAmount>>
{
}
