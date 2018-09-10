<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Note_Create"  Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="../Content/Note/create.css"/>

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
</asp:Content>