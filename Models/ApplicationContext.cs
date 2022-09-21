using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        //reference our Model classes
        public DbSet<Baker> Bakers {get; set;}
        public DbSet<Bread> Breads {get; set;}
    }
}