using MediatR;

namespace Application.Features.Debt.Delete.PreviousPercentage;

public class DeleteDebtPreviousPercentage(Guid id) : IRequest<Persistence.Entities.Debt.PreviousPercentage>
{
    public Guid Id { get; set; } = id;
}
