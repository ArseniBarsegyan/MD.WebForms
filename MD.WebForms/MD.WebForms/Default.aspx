<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/default.css"/>

    <div class="header" style="padding-top: 0;">
        <div class="container">
            <h1>MD</h1>
            <a runat="server" href="~/Account/Login" class="button-simple button-success">SignIn</a>
        </div>
    </div>
</asp:Content>
