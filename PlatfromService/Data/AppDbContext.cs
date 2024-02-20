using Microsoft.EntityFrameworkCore;
using PlatfromService.Models;
namespace PlatfromService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Platform> platforms { get; set; }
    }
}
