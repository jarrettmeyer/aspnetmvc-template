<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Contact>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">New Contact</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form action="<%= Url.Action("Create") %>" method="post">
        <fieldset>
            <legend>New Contact</legend>
            <%= Html.AntiForgeryToken() %>
            <p>
                <%= Html.Label("First Name", "FirstName") %>
                <%= Html.TextBox("FirstName", Model.FirstName) %>
            </p>
            <p>
                <%= Html.Label("Last Name", "LastName") %>
                <%= Html.TextBox("LastName", Model.LastName) %>
            </p>
            <p>
                <%= Html.Label("Email Address", "EmailAddress") %>
                <%= Html.TextBox("EmailAddress", Model.EmailAddress) %>
            </p>
            <p>
                <%= Html.Submit("Create") %>
            </p>
            
        </fieldset>
    </form>

</asp:Content>
