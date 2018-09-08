using System.Data.Linq.Mapping;

namespace MD.AdoNet
{
    [Table(Name = "Photos")]
    public class Photo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public int NoteId { get; set; }

        [Column]
        public string Image { get; set; }
    }
}