using Microsoft.EntityFrameworkCore;

namespace car.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }

        public DbSet<Insuree> Insurees { get; set; }
    }
} 