using MediatR;

namespace Application.Features.Debt.Read.Payment;

public class ReadDebtPayment(Guid id) : IRequest<List<Persistence.Entities.Debt.Payment>>
{
    public Guid Id { get; set; } = id;
}
