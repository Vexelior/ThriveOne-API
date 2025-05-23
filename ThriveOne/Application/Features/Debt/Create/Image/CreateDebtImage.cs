using MediatR;

namespace Application.Features.Debt.Create.Image;

public class CreateDebtImage : IRequest<Persistence.Entities.Debt.Image>
{
    public string Name { get; set; }
    public string Source { get; set; }
    public DateTime Uploaded { get; set; }
}
