<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Contact>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Contacts</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.IncludeJs("application.contacts.js") %>
    <h2>Contacts</h2>
    
    <% if (Model.Any()) { %> 
        <table>
            <thead>
                <tr>
                    <td>ID</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Email Address</td>
                    <td></td>
                </tr>
            </thead>
            <tbody>
                <% foreach (var contact in Model) { %> 
                    <tr>
                        <td><%= Html.Encode(contact.Id) %></td>
                        <td><%= Html.Encode(contact.FirstName) %></td>
                        <td><%= Html.Encode(contact.LastName) %></td>
                        <td><%= Html.Encode(contact.EmailAddress) %></td>
                        <td><%= Html.ActionLink("Notes", "Index", new { controller = "Notes", contactId = contact.Id })%> |
                            <%= Html.ShowLink("Details", contact.Id) %> | 
                            <%= Html.EditLink("Edit", contact.Id)%> |
                            <%= Html.DeleteLink("Delete", contact.Id)%>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    
    <% } else { %>
        <h3 class="error">No Contacts Found</h3> 
    <% } %>
    
    <p><%= Html.ActionLink("Create New Contact", "New") %></p>    

</asp:Content>
