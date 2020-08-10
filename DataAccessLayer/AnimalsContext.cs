using System.Data.Entity;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess
{
    public class AnimalsContext : IdentityDbContext<Emploee>
    {
        public AnimalsContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CustomInitializer());
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Home> Homes { get; set; }
    }
}
