using System;
using System.Data.Linq.Mapping;

namespace MD.AdoNet
{
    [Table(Name = "Notes")]
    public class Note
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Description")]
        public string Description { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        [Column(Name = "UserId")]
        public string UserId { get; set; }
    }
}