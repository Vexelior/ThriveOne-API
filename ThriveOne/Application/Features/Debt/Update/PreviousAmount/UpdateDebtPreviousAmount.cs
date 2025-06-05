using MediatR;

namespace Application.Features.Debt.Update.PreviousAmount;

public class UpdateDebtPreviousAmount : IRequest<Persistence.Entities.Debt.PreviousAmount>
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public double PercentageChange { get; set; }
    public Guid DebtId { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
}
