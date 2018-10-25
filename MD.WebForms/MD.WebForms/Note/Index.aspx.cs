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

                var photos = context.GetTable<Photo>();
                var userPhotos = from n in notes
                    join p in photos on n.Id equals p.NoteId
                    orderby p.Id descending
                    select new {p.Image, p.Name, p.Id, p.NoteId };

                var notesWithoutPhotos = from d in notes
                    where !(from n in notes
                        join p in photos on n.Id equals p.NoteId
                        select n.Id).Contains(d.Id) select new
                    {
                        d.Id,
                        d.Date,
                        d.Description,
                        Image = "No photo"
                    };

                var photoGroups = from t in (from n in notes
                        join p in userPhotos on n.Id equals p.NoteId
                        orderby p.Id descending
                        select new
                        {
                            n.Id,
                            n.Date,
                            n.Description,
                            p.Image
                        })
                    group t by t.Id;

                var viewResult = new List<object>();
                foreach (var note in notesWithoutPhotos)
                {
                    viewResult.Add(note);
                }

                foreach (var group in photoGroups)
                {
                    Console.WriteLine(group.Key);
                    var firstItemInAGroup = group.FirstOrDefault();
                    if (firstItemInAGroup != null)
                    {
                        viewResult.Add(new { firstItemInAGroup.Id, firstItemInAGroup.Date, firstItemInAGroup.Description, firstItemInAGroup.Image});
                    }
                }

                ListView.DataSource = viewResult.AsQueryable();
                Session["Notes"] = viewResult;
                ListView.DataBind();
            }   
        }
    }

    protected void NewNote(object sender, EventArgs e)
    {
        Response.Redirect("Create.aspx");
    }

    protected void OnNoteClick(object sender, EventArgs e)
    {
        Loader.Visible = true;
        var link = sender as LinkButton;
        var id = link?.ClientID;
        var selectedIndex = int.Parse(id.Substring(id.Length - 1));
        Loader.Visible = false;
    }
}