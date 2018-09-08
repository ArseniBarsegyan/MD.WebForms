using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MD.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}