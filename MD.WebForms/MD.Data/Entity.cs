using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MD.Data
{
    /// <summary>
    /// Base entity for all entities of the application, except <see cref="ApplicationUser"/>
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Primary key, int number
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}