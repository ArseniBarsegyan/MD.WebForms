using System;
using System.Web.UI;

public partial class Note_Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void NewNote(object sender, EventArgs e)
    {
        Response.Redirect("Create.aspx");
    }
}