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

                var result = from t in (from n in notes
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

                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);
                    var firstItemInAGroup = group.FirstOrDefault();
                    viewResult.Add(new { group.Key, firstItemInAGroup.Image, firstItemInAGroup.Description, firstItemInAGroup.Date });
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

    protected void ListItem_OnClick(object sender, EventArgs e)
    {
        var test = sender as LinkButton;
        test.CssClass = "list-group-item clearfix active";
    }
}