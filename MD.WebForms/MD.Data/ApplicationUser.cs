using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MD.Data
{
    /// <summary>
    /// Application user extends <see cref="IdentityUser"/>
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Notes = new List<Note>();
        }

        /// <summary>
        /// Notes of user.
        /// </summary>
        public virtual IEnumerable<Note> Notes { get; set; }
    }
}