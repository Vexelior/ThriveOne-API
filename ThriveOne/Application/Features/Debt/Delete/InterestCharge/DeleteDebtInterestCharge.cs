using MediatR;

namespace Application.Features.Debt.Delete.InterestCharge;

public class DeleteDebtInterestCharge(Guid id) : IRequest<Persistence.Entities.Debt.InterestCharge>
{
    public Guid Id { get; set; } = id;
}
