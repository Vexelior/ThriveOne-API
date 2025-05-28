using MediatR;

namespace Application.Features.Debt.Create.PreviousAmount;

public class CreateDebtPreviousAmount : IRequest<Persistence.Entities.Debt.PreviousAmount>
{
    public double Amount { get; set; }
    public double PercentageChange { get; set; }
    public Guid DebtId { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
}
