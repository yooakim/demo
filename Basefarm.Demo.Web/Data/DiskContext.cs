using Basefarm.Demo.Web.Entities;
using Microsoft.EntityFrameworkCore;
namespace Basefarm.Demo.Web.Data
{
    public class DiskContext : DbContext
    {
        public DiskContext(DbContextOptions<DiskContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<LogicalDisk> LogicalDisks { get; set; }
        public DbSet<PSDrive> PSDrives { get; set; }

    }
}