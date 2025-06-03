using MediatR;

namespace Application.Features.Debt.Read.Payment;

public class ReadDebtPayments : IRequest<List<Persistence.Entities.Debt.Payment>>
{
}
