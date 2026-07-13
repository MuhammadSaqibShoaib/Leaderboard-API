using LeaderboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
