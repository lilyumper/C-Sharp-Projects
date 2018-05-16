using Microsoft.EntityFrameworkCore;   

namespace Restauranter.Models
{
    public class RestauranterContext : DbContext
    {
        public RestauranterContext(DbContextOptions<RestauranterContext> options) : base(options){

        }
        public DbSet<Reviews> Reviews {get; set;}
    }
}