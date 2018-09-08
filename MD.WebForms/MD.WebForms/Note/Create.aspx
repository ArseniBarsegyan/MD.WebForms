<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Note_Create"  Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="col-xs-8">
            <h2>New note</h2>
            <hr/>
            
            <div class="form-horizontal" runat="server">
                <div class="form-group">
                    <asp:TextBox ID="description" runat="server" TextMode="multiline" Rows="5" CssClass="form-control"></asp:TextBox>
                    <asp:FileUpload runat="server" onchange="this.form.submit()" class="upload" id="photos" name="Photos" AllowMultiple="True" />
                    <asp:Label runat="server" AssociatedControlID="photos">Pick photos...</asp:Label>
                    <asp:Label runat="server" ID="fileNames"></asp:Label>
                </div>
                <asp:Button runat="server" OnClick="CreateNoteButton_OnClick" Text="Create" CssClass="button-simple button-info"/>
            </div>
        </div>
    </div>
    
    <style type="text/css">
        /* Create new note page styles */
        .upload {
            width: 0.1px;
            height: 0.1px;
            opacity: 0;
            cursor: pointer;
        }

        .upload + label {
            border: none; /* Remove borders */
            color: black; /* Add a text color */
            padding: 14px 28px; /* Add some padding */
            cursor: pointer;
            background-color: #e7e7e7;
            display: inline-block;
        }

        .upload:focus + label {
            cursor: pointer;
            outline: 1px dotted #000;
            outline: -webkit-focus-ring-color auto 5px;
        }
    </style>
</asp:Content>