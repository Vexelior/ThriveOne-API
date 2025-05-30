using MediatR;

namespace Application.Features.Debt.Read.History;

public class ReadDebtHistories : IRequest<List<Persistence.Entities.Debt.History>>
{
}
