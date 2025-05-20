namespace Persistence.Entities.Debt;

public class InterestCharge
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
