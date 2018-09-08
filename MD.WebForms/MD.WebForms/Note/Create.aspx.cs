using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using MD.Data;
using Microsoft.AspNet.Identity;

public partial class Note_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack && photos.PostedFiles.Any())
        {
            if (!string.IsNullOrEmpty(photos.PostedFiles.ElementAt(0).FileName))
            {
                var photoModels = new List<Photo>();
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
                    photoModels.Add(photoModel);
                }
                Session["UploadedPhotos"] = photoModels;
            }
        }
    }

    protected async void CreateNoteButton_OnClick(object sender, EventArgs e)
    {
        if (User != null && User.Identity.IsAuthenticated)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            if (Session["UploadedPhotos"] is List<Photo> photoModels)
            {
                var note = new Note
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    Description = description.Text
                };

                foreach (var photoModel in photoModels)
                {
                    photoModel.Note = note;
                }

                note.Photos = photoModels;

                using (var context = new AppIdentityDbContext())
                using (var photoRepository = new Repository<Photo>(context))
                {
                    photoRepository.Create(photoModels);
                    await photoRepository.SaveAsync();
                }
                
                Session.Remove("UploadedPhotos");
            }
            Server.Transfer("Index.aspx", true);
        }
    }
}