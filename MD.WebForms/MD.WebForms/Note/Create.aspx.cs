using System;
using System.Text;

public partial class Note_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack && photos.PostedFiles != null)
        {
            var builder = new StringBuilder();

            foreach (var file in photos.PostedFiles)
            {
                builder.Append(file.FileName);
                builder.Append(" ");
            }
            fileNames.Text = builder.ToString();
        }
    }

    protected void CreateNoteButton_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}