<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr class="contact" id="contact-<%= Model.Id %>">
    <td><%= Model.Id %></td>
    <td><%= Model.FirstName %></td>
    <td><%= Model.LastName %></td>
    <td><%= Model.EmailAddress %></td>
    <td>
        <%= Html.ShowLink("Details", Model.Id, new { @class = "show-contact" }) %> |
        <%= Html.ActionLink("Notes", "Index", new { controller = "Notes", contactId = Model.Id }) %> |
        <%= Html.EditLink("Edit", Model.Id, new { @class = "edit-contact" }) %> |
        <%= Html.DeleteLink("Delete", Model.Id, new { @class = "delete-contact" }) %>
    </td>
</tr>

