<%@ Page Title="Notes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Note_Index" Async="true" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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
                        <div class="col-xs-12">
                            <asp:ListView runat="server" ID="ListView">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" style="cursor: pointer;" CssClass="list-group-item clearfix" OnClick="ListItem_OnClick">
                                        <span class="pull-left">
                                            <img src='<%# $"data:image/gif;base64, {Eval("Image")}" %>' class="img-responsive note-image" alt="Note photo"/>
                                        </span>
                                        <div class="pull-right text-container">
                                            <h4><asp:Label runat="server" Text='<%#string.Format(new CultureInfo("en-GB"), "{0:MMM d, yyyy}", Eval("Date")) %>'></asp:Label></h4>
                                            <p class="list-group-item-text"><asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label></p>
                                        </div>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <style type="text/css">
        .text-container {
            text-overflow: ellipsis;
            width: 200px;
            height: 70px;
            white-space: normal;
            overflow: hidden;
            padding: 10px;
        }

        .note-image {
            max-width: 160px;
            max-height: 100px;
        }
    </style>
</asp:Content>
