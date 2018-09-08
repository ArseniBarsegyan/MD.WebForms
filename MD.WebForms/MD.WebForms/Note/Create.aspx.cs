using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using MD.Data;
using MD.Identity;
using Microsoft.AspNet.Identity;

public partial class Note_Create : System.Web.UI.Page
{
    private IRepository<Note> _repository;
    private readonly List<Photo> _photos = new List<Photo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _repository = new NoteRepository(new AppIdentityDbContext());
        }

        if (IsPostBack && photos.PostedFiles != null)
        {
            var builder = new StringBuilder();

            foreach (var file in photos.PostedFiles)
            {
                builder.Append(file.FileName);
                builder.Append(" ");
            }
            fileNames.Text = builder.ToString();

            foreach (var file in photos.PostedFiles)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
                string imageContent = Convert.ToBase64String(fileData);
                string fileName = file.FileName;

                var photoModel = new Photo
                {
                    Image = imageContent,
                    Name = fileName
                };
                _photos.Add(photoModel);
            }
        }
    }

    protected async void CreateNoteButton_OnClick(object sender, EventArgs e)
    {
        if (User != null && User.Identity.IsAuthenticated)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            var note = new Note
            {
                UserId = userId,
                Date = DateTime.Now,
                Description = description.Text,
                Photos = _photos
            };

            foreach (var photoModel in _photos)
            {
                photoModel.Note = note;
            }

            _repository.CreateAsync(note);
            await _repository.SaveAsync();
        }
        
        Response.Redirect("Index.aspx");
    }
}