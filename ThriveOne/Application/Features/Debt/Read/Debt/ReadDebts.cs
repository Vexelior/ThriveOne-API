using MediatR;

namespace Application.Features.Debt.Read.Debt;

public class ReadDebts : IRequest<List<Persistence.Entities.Debt.Debt>>
{
}
