using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MD.Data
{
    /// <summary>
    /// Extends <see cref="IdentityDbContext"/> and contains additional tables - <see cref="Note"/> and <see cref="Photo"/>
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Table Notes.
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Table Photos.
        /// </summary>
        public DbSet<Photo> Photos { get; set; }
    }
}