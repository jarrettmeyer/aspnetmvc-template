<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr>
    <td><%= Model.Id %></td>
    <td><%= Model.FirstName %></td>
    <td><%= Model.LastName %></td>
    <td><%= Model.EmailAddress %></td>
    <td>
    </td>
</tr>

