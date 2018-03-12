using Basefarm.Demo.Web.Entities;
using Microsoft.EntityFrameworkCore;
namespace Basefarm.Demo.Web.Data
{
    public class DiskContext : DbContext
    {
        public DiskContext(DbContextOptions<DiskContext> options) : base(options)
        {
        }

        public DbSet<LogicalDisk> LogicalDisks { get; set; }
    }
}