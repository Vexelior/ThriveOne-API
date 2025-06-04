using MediatR;

namespace Application.Features.Debt.Read.PreviousPercentage;

public class ReadDebtPreviousPercentage(Guid id) : IRequest<Persistence.Entities.Debt.PreviousPercentage>
{
    public Guid Id { get; set; } = id;
}
