<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Note>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">New Note</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <form action="<%= Url.Action("Create") %>" method="post">
        <fieldset>
            <legend>New Note</legend>
            <p>
                <%= Html.Label("Note", "NoteText") %>
                <%= Html.TextArea("NoteText", Model.NoteText) %>
            </p>
            <p>
                <%= Html.Submit("Create Note") %>
            </p>
        </fieldset>
    </form>
</asp:Content>
