using MediatR;

namespace Application.Features.Debt.Delete.Image;

public class DeleteDebtImage(Guid id) : IRequest<Persistence.Entities.Debt.Image>
{
    public Guid Id { get; set; } = id;
}
