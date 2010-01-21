<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Note>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Edit Note</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.IncludeJs("application.notes.js") %>

    <form action="<%= Url.Action("Update") %>" method="post">
        <fieldset>
            <legend>Edit Note</legend>
            <input type="hidden" id="ContactId" name="ContactId" value="<%= Model.Contact.Id %>" />
            <p>
                <%= Html.Label("Note", "NoteText") %>
                <%= Html.TextArea("NoteText", Model.NoteText) %>
            </p>
            <p>
                <%= Html.Submit("Update Note", "update-note") %>
                <%= Html.ActionLink("Cancel", "Index", new { contactId = Model.Contact.Id }) %>
            </p>
        </fieldset>
    </form>

</asp:Content>
