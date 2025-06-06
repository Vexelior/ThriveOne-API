using MediatR;

namespace Application.Features.Debt.Read.History;

public class ReadDebtHistory(Guid id) : IRequest<List<Persistence.Entities.Debt.History>>
{
    public Guid Id { get; set; } = id;
}
