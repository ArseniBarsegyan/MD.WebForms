using System;
using System.Collections.Generic;
using MD.Data;

namespace MD.Identity
{
    public class Note : Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<Photo> Photos { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}