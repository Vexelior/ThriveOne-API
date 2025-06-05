using MediatR;

namespace Application.Features.Debt.Delete.PreviousAmount;

public class DeleteDebtPreviousAmount(Guid id) : IRequest<Persistence.Entities.Debt.PreviousAmount>
{
    public Guid Id { get; set; } = id;
}
