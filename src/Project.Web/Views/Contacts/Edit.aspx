<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.IncludeJs("application.contacts.js") %>    
    <form action="<%= Url.Action("Update") %>" method="post">        
        <fieldset>
            <legend>Edit Contact</legend>
            <%=Html.AntiForgeryToken() %>
            <p>
                <%= Html.Label("First Name", "FirstName") %>
                <%= Html.TextBox("FirstName", Model.FirstName) %>
            </p>
            <p>
                <%= Html.Label("Last Name", "LastName")%>
                <%= Html.TextBox("LastName", Model.LastName)%>
            </p>
            <p>
                <%= Html.Label("Email Address", "EmailAddress")%>
                <%= Html.TextBox("EmailAddress", Model.EmailAddress)%>
            </p>
            <p>
                <%= Html.Submit("Update Contact", "update-contact") %> |
                <%= Html.ActionLink("Return to Contact List", "Index") %>
            </p>
        </fieldset>
    </form>

</asp:Content>
