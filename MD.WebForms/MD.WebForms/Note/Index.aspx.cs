using System;
using System.Web;
using System.Web.UI;
using MD.Identity;
using Microsoft.AspNet.Identity;

public partial class Note_Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var repository = new NoteRepository(new AppIdentityDbContext());

            if (User != null && User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var allNotes = repository.GetAll(userId);
            }
        }
    }

    protected void NewNote(object sender, EventArgs e)
    {
        Response.Redirect("Create.aspx");
    }
}