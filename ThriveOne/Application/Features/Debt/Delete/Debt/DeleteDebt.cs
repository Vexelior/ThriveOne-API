using MediatR;


namespace Application.Features.Debt.Delete.Debt;

public class DeleteDebt(Guid id) : IRequest<Persistence.Entities.Debt.Debt>
{
    public Guid Id { get; set; } = id;
}
