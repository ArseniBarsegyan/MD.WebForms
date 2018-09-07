using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MD.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext(string schemaName)
            : base("DefaultConnection")
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}