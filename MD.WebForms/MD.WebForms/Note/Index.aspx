<%@ Page Title="Notes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Note_Index" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    
    <div class="container" style="padding-top: 20px;">
        <!-- Loading indicator will be here -->
        
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col-xs-12" style="padding-left: 0;">
                        <asp:Button runat="server" OnClick="NewNote" Text="New note" CssClass="button-simple button-success" />
                        <hr/>
                    </div>
                    <div class="row">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
