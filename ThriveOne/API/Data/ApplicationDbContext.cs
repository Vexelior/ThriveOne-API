using API.Entities;
using API.Entities.Debt;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Debt> Debts { get; set; }
    public DbSet<PreviousAmount> DebtPreviousAmounts { get; set; }
    public DbSet<History> DebtHistories { get; set; }
    public DbSet<Payment> DebtPayments { get; set; }
    public DbSet<PreviousPercentage> DebtPreviousPercentages { get; set; }
    public DbSet<InterestCharge> DebtInterestCharges { get; set; }
    public DbSet<Image> DebtImages { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<Todo> Todos { get; set; }
}
