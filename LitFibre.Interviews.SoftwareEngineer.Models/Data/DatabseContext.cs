using Microsoft.EntityFrameworkCore;
using LitFibre.Interviews.SoftwareEngineer.Models.Orders;

namespace LitFibre.Interviews.SoftwareEngineer.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; } = default!;
    }
}
