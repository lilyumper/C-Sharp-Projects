
using Microsoft.EntityFrameworkCore;

namespace Banker.Models
{
    public class BankerContext: DbContext
    {
        public BankerContext(DbContextOptions<BankerContext> options): base(options){}

        public DbSet<User> Users {get; set;}

        public DbSet<Transaction> Transactions {get; set;}
    }
}