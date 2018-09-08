using System;
using System.Collections.Generic;

namespace MD.Data
{
    /// <summary>
    /// Note that user can make.
    /// </summary>
    public class Note : Entity
    {
        public Note()
        {
            Photos = new List<Photo>();
        }

        /// <summary>
        /// Note text.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Note creation date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Collection of photos that note can contain.
        /// </summary>
        public virtual IEnumerable<Photo> Photos { get; set; }

        /// <summary>
        /// Foreign key to table <see cref="ApplicationUser"/>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation property to <see cref="ApplicationUser"/>
        /// </summary>
        public virtual ApplicationUser User { get; set; }
    }
}