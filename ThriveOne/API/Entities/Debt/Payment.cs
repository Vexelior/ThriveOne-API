namespace API.Entities.Debt;

public class Payment
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
}
