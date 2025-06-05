using MediatR;

namespace Application.Features.Debt.Update.Image;

public class UpdateDebtImage : IRequest<Persistence.Entities.Debt.Image>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Source { get; set; }
    public DateTime Uploaded { get; set; }
}
