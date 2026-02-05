using Microsoft.EntityFrameworkCore;
using CampusLostFound.Api.Models;

namespace CampusLostFound.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LostItem> LostItems { get; set; }
        public DbSet<FoundItem> FoundItems { get; set; }
    }
}
