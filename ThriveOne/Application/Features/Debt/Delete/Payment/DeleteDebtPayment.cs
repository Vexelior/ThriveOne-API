using MediatR;

namespace Application.Features.Debt.Delete.Payment;

public class DeleteDebtPayment(Guid id) : IRequest<Persistence.Entities.Debt.Payment>
{
    public Guid Id { get; set; } = id;
}
