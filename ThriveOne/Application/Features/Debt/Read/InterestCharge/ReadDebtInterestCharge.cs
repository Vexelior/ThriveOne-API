using MediatR;

namespace Application.Features.Debt.Read.InterestCharge;

public class ReadDebtInterestCharge(Guid id) : IRequest<List<Persistence.Entities.Debt.InterestCharge>>
{
    public Guid Id { get; set; } = id;
}
