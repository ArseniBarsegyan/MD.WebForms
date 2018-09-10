using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MD.AdoNet;
using Microsoft.AspNet.Identity;

public partial class Note_Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();

                var context = new DataContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                var notes = context.GetTable<Note>().Where(x => x.UserId == userId);
                var allIds = from note in notes select note.Id;

                var photos = context.GetTable<Photo>()
                    .Where(selectedPhoto => allIds.Any(x => selectedPhoto.Id == x));

                var photosGroupedByNoteId = from g in (from n in notes
                                                       join p in photos on n.Id equals p.NoteId
                                                       orderby p.Id descending
                                                       select new
                                                       {
                                                           n.Id,
                                                           p.Image
                                                       })
                                            group g by g.Id;

                var viewResult = new List<object>();

                foreach (var group in photosGroupedByNoteId)
                {
                    var firstItemInAGroup = group.FirstOrDefault();
                    viewResult.Add(new { group.Key, firstItemInAGroup.Image });
                }

                ListView.DataSource = viewResult.AsQueryable();
                ListView.DataBind();
            }   
        }
    }

    protected void NewNote(object sender, EventArgs e)
    {
        Response.Redirect("Create.aspx");
    }
}