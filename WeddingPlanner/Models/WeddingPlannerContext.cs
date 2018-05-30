using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        public WeddingPlannerContext(DbContextOptions<WeddingPlannerContext> options) : base(options){}

        public DbSet<User> Users {get; set;}

        public DbSet<Plan> Plans {get; set;}

        public DbSet<Wedding> Weddings {get; set;}
    }
    
}