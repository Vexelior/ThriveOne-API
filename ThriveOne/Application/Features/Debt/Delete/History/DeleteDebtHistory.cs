using MediatR;

namespace Application.Features.Debt.Delete.History;

public class DeleteDebtHistory(Guid id) : IRequest<Persistence.Entities.Debt.History>
{
    public Guid Id { get; set; } = id;
}
