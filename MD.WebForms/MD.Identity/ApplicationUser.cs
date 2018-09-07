using System.Collections.Generic;
using MD.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MD.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Notes = new List<Note>();
        }

        public virtual IEnumerable<Note> Notes { get; set; }
    }
}