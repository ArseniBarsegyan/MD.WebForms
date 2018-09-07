﻿using MD.Data;

namespace MD.Identity
{
    public class Photo : Entity
    {
        public string Name { get; set; }
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }
        public string Image { get; set; }
    }
}