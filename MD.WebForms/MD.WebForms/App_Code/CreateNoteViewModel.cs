using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MD.WebForms
{
    public class CreateNoteViewModel
    {
        [Required(ErrorMessage = ConstantsHelper.NoteDescriptionRequired)]
        public string Description { get; set; }
        public IEnumerable<HttpPostedFile> Photos { get; set; }
    }
}