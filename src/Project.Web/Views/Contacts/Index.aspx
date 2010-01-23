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
                    <% Html.RenderPartial("ShowControl", contact); %>
                <% } %>
            </tbody>
        </table>
    
    <% } else { %>
        <h3 class="error">No Contacts Found</h3> 
    <% } %>
    
    <p><%= Html.ActionLink("Create New Contact", "New") %></p>    

</asp:Content>
