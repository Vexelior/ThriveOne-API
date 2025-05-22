using MediatR;

namespace Application.Features.Debt.Read.Debt;

public class ReadDebt(Guid id) : IRequest<Persistence.Entities.Debt.Debt>
{
    public Guid Id { get; set; } = id;
}
