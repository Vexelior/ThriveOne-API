namespace API.Entities.Debt;

public class PreviousPercentage
{
    public Guid Id { get; set; }
    public Guid DebtId { get; set; }
    public double Percent { get; set; }
    public DateTime Date { get; set; }
}
