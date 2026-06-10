using Microsoft.EntityFrameworkCore;
using Dive_Center.Models;

namespace Dive_Center.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Diver> Divers { get; set; }
    }
}