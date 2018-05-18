using Microsoft.EntityFrameworkCore;

namespace Entitypractice.Models
{
    public class EntitypracticeContext : DbContext
    {
        public EntitypracticeContext(DbContextOptions<DbContext> options) : base(options) {

        }
        //public DbSet<Person> Users {get; set;}
    }
}