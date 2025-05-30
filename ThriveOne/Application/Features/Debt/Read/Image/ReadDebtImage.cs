using MediatR;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImage(Guid id) : IRequest<Persistence.Entities.Debt.Image>
{
    public Guid Id { get; set; } = id;
}
