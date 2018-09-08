using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
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

                var photos = context.GetTable<Photo>();
                var selectedPhotos = photos.Where(selectedPhoto => allIds.Any(x => selectedPhoto.Id == x));

                GridView.DataSource = notes;
                GridView.DataBind();
            }   
        }
    }

    protected void NewNote(object sender, EventArgs e)
    {
        Response.Redirect("Create.aspx");
    }
}