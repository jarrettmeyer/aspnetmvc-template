<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<INotification>>" %>

<% if (Model.HasNotifications()) { %>
    <div class="notifications-wrapper">
        <% if (Model.HasNotifications<SuccessNotification>()) { %> 
            <div class="notification success-notification">
                <ul>
                    <% foreach (var notification in Model.GetNotifications<SuccessNotification>()) { %> 
                        <li><%= Html.Encode(notification.Message) %></li>
                    <% } %>
                </ul>                
            </div>
        <% } %>
        <% if (Model.HasNotifications<ErrorNotification>()) { %> 
            <div class="notification error-notification">
                <ul>
                    <% foreach (var notification in Model.GetNotifications<ErrorNotification>()) { %> 
                        <li><%= Html.Encode(notification.Message) %></li>
                    <% } %>
                </ul>                
            </div>
        <% } %>
        <% if (Model.HasNotifications<WarningNotification>()) { %> 
            <div class="notification warning-notification">
                <ul>
                    <% foreach (var notification in Model.GetNotifications<WarningNotification>()) { %> 
                        <li><%= Html.Encode(notification.Message) %></li>
                    <% } %>
                </ul>                
            </div>
        <% } %>
        <% if (Model.HasNotifications<InfoNotification>()) { %> 
            <div class="notification info-notification">
                <ul>
                    <% foreach (var notification in Model.GetNotifications<InfoNotification>()) { %> 
                        <li><%= Html.Encode(notification.Message) %></li>
                    <% } %>
                </ul>                
            </div>
        <% } %>
    </div>
<% } %>
