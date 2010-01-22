<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ListNotesViewModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Notes</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.IncludeJs("application.notes.js") %>
    <h2>Notes for <%= Html.Encode(Model.Contact.EmailAddress) %></h2>
    
    <table>
        <thead>
            <tr>
                <td>Note</td>
                <td>Date Added</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var note in Model.Notes) { %> 
                <tr>
                    <td><%= Html.SimpleFormat(note.NoteText) %></td>
                    <td><%= Html.Encode(note.DateAdded) %></td>    
                    <td><%= Html.ShowLink("Details", note.Id) %> |
                        <%= Html.EditLink("Edit", note.Id) %> |
                        <%= Html.DeleteLink("Delete", note.Id, "delete-note") %>
                    </td>                
                </tr>
            <% } %>
        </tbody>
    </table>
    
    <p>
        <%= Html.ActionLink("Add Note", "New", new { contactId = Model.Contact.Id }) %>
        <%= Html.ActionLink("Return to Contacts", "Index", "Contacts") %>
    </p>
</asp:Content>
