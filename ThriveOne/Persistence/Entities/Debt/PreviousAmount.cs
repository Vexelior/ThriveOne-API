namespace Persistence.Entities.Debt;

public class PreviousAmount
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public double PercentageChange { get; set; }
    public Guid DebtId { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
}
