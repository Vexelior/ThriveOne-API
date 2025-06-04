using MediatR;

namespace Application.Features.Debt.Read.PreviousPercentage;

public class ReadDebtPreviousPercentages : IRequest<List<Persistence.Entities.Debt.PreviousPercentage>>
{
}
