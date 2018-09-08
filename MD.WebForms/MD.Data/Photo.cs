namespace MD.Data
{
    /// <summary>
    /// Photo that can be included into Note.
    /// </summary>
    public class Photo : Entity
    {
        /// <summary>
        /// Photo name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Foreign key to table <see cref="MD.Data.Note"/>
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Navigation property to <see cref="MD.Data.Note"/>
        /// </summary>
        public virtual Note Note { get; set; }

        /// <summary>
        /// Photo content as Base64 string.
        /// </summary>
        public string Image { get; set; }
    }
}