<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Note>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Note</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<p><strong>Note:</strong></p>
<pre><%= Html.Encode(Model.NoteText) %></pre>

<p><strong>Date Added:</strong> <%= Html.Encode(Model.DateAdded) %></p>

<p><strong>Contact:</strong> <%= Html.ActionLink(Model.Contact.EmailAddress, "Show", new { controller = "Contacts", id = Model.Contact.Id }) %></p>

</asp:Content>
