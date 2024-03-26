using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TomatoSorterDashboard.Models.Tomato> Tomato { get; set; } = default!;
    }
}
