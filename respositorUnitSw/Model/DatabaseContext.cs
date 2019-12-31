using Microsoft.EntityFrameworkCore;


namespace respositorUnitSw.Model
{

    public class DatabaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> context) : base(context)
        {

        }

    }
}
