using Microsoft.EntityFrameworkCore;
using NurseryLink.Models;

namespace NurseryLink.Data
{
    public class NurseryContext : DbContext
    {
        public NurseryContext(DbContextOptions<NurseryContext> options) : base(options) { }

        public DbSet<Nursery> Nurseries { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}
