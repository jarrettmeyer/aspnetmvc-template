<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contact
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Contact</h2>
    
    <p><strong>First Name:</strong> <%= Html.Encode(Model.FirstName) %></p>
    
    <p><strong>Last Name:</strong> <%= Html.Encode(Model.LastName) %></p>
    
    <p><strong>Email Address:</strong> <%= Html.Encode(Model.EmailAddress) %></p>
    
    <p>
        <%= Html.ActionLink("Notes", "Index", new { controller = "Notes", contactId = Model.Id }) %>
        <%= Html.ActionLink("Edit", "Edit") %>
        <%= Html.ActionLink("List all Contacts", "Index") %>
    </p>

</asp:Content>
