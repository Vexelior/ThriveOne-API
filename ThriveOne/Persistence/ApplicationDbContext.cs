using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities.Todo;
using Persistence.Entities.WorkTask;

namespace Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<Todo> Todos { get; set; }
}
