using MediatR;

namespace Application.Features.Debt.Update.Debt;

public class UpdateDebt : IRequest<Persistence.Entities.Debt.Debt>
{
    public Guid Id { get; set; }
    public string Creditor { get; set; }
    public double Amount { get; set; }
    public double RemainingAmount { get; set; }
    public double PreviousAmount { get; set; }
    public string Notes { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateEdited { get; set; }
    public double PercentageChange { get; set; }
    public string Type { get; set; }
    public string Image { get; set; }
    public Guid ImageId { get; set; }
    public string ImageSource { get; set; }
    public double InterestRate { get; set; }
    public double LastPayment { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public double MinimumPayment { get; set; }
}
