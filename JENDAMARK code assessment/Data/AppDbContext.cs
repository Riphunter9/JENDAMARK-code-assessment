using Microsoft.EntityFrameworkCore;

namespace JENDAMARK_code_assessment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Device> Devices { get; set; }

    }
}
