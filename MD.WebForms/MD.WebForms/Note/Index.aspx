<%@ Page Title="Notes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Note_Index" Async="true" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="../Content/Note/index.css"/>
    <div class="container" style="padding-top: 20px;">
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
                                    <asp:Panel runat="server" ID="listItem">
                                        <asp:LinkButton runat="server" style="cursor: pointer;" class="list-group-item clearfix" OnClick="OnNoteClick" >
                                            <span class="pull-left">
                                                <img src='<%# $"data:image/gif;base64, {Eval("Image")}" %>' class="img-responsive note-image" alt="No photo"/>
                                            </span>
                                            <div class="pull-right text-container">
                                                <h4><asp:Label runat="server" Text='<%#string.Format(new CultureInfo("en-GB"), "{0:MMM d, yyyy}", Eval("Date")) %>'></asp:Label></h4>
                                                <p class="list-group-item-text"><asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label></p>
                                            </div>
                                        </asp:LinkButton>                                        
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel runat="server" ID="noteDetails" CssClass="col-md-7">
                <h2>No note selected</h2>
            </asp:Panel>
        </div>
        <!-- Loading indicator will be here -->
        <asp:Panel runat="server" ID="Loader" CssClass="loader"></asp:Panel>
    </div>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(".loader").hide();
        });
    </script>
    
</asp:Content>
