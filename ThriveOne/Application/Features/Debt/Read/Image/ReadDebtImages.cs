using MediatR;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImages : IRequest<List<Persistence.Entities.Debt.Image>>
{
}
