using MediatR;

namespace Application.Features.Debt.Read.PreviousAmount;

public class ReadDebtPreviousAmount(Guid id) : IRequest<List<Persistence.Entities.Debt.PreviousAmount>>
{
    public Guid Id { get; set; } = id;
}
