using MediatR;

namespace Application.Features.Debt.Read.Image;

public class ReadDebtImageByName(string name) : IRequest<Persistence.Entities.Debt.Image>
{
    public string Name { get; set; } = name;
}
