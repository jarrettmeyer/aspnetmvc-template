using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Project.Core.Lib.Html
{
    public static class ExtensionsOfHtmlHelper
    {
        public const string CssPath = "~/Content/Stylesheets/";
        public const string JsPath = "~/Content/Scripts/";

        public static string DeleteLink(this HtmlHelper html, string linkText, int id)
        {
            return html.DeleteLink(linkText, id, new { @class = "delete-link"});
        }

        public static string DeleteLink(this HtmlHelper html, string linkText, int id, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);
            var url = urlHelper.Action("Delete", new { id });
            var sb = new StringBuilder();
            sb.AppendFormat("<form action=\"{0}\" method=\"post\" class=\"inline\">", url);
            sb.Append(html.AntiForgeryToken());
            sb.Append(html.ActionLink(linkText, "Delete", new { id }, htmlAttributes));
            sb.Append("</form>");
            return sb.ToString();
        }

        public static string EditLink(this HtmlHelper html, string linkText, int id)
        {
            return html.ActionLink(linkText, "Edit", new { id });
        }

        public static string EditLink(this HtmlHelper html, string linkText, int id, object htmlAttributes)
        {
            return html.ActionLink(linkText, "Edit", new { id }, htmlAttributes);
        }

        public static string IncludeCss(this HtmlHelper html, string css)
        {
            Ensure.ArgumentNotNullOrEmpty(css, "css");
            var fullPath = string.Concat(CssPath, css);
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);            
            var contentPath = urlHelper.Content(fullPath);
            return string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\"/>", contentPath);
        }

        public static string IncludeJs(this HtmlHelper html, string js)
        {
            Ensure.ArgumentNotNull(js, "js");
            var fullPath = string.Concat(JsPath, js);
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);
            var contentPath = urlHelper.Content(fullPath);
            return string.Format("<script language=\"javascript\" type=\"text/javascript\" src=\"{0}\"></script>", contentPath);
        }        

        public static string Label(this HtmlHelper html, string labelText, string forValue)
        {
            return string.Format("<label for=\"{0}\">{1}</label>", forValue, labelText);
        }

        public static string ShowLink(this HtmlHelper html, string linkText, int id)
        {
            return html.ActionLink(linkText, "Show", new { id });
        }

        public static string ShowLink(this HtmlHelper html, string linkText, int id, object htmlAttributes)
        {
            return html.ActionLink(linkText, "Show", new { id }, htmlAttributes);
        }

        public static string ShowLink(this HtmlHelper html, string linkText, string controller, int id)
        {
            return html.ActionLink(linkText, "Show", controller, id);
        }

        public static string ShowLink(this HtmlHelper html, string linkText, string controller, int id, object htmlAttributes)
        {
            return html.ActionLink(linkText, "Show", controller, id, htmlAttributes);
        }

        public static string SimpleFormat(this HtmlHelper html, object obj)
        {
            if (obj == null) return string.Empty;
            var text = html.Encode(obj);
            text = Regex.Replace(text, "\n{2,}", "</p><p>");
            text = Regex.Replace(text, "\n", "<br/>");
            text = text.Prepend("<p>");
            text = text.Append("</p>");
            return text;
        }

        public static string Submit(this HtmlHelper html, string buttonText)
        {
            return string.Format("<input type=\"submit\" value=\"{0}\"/>", buttonText);
        }

        public static string Submit(this HtmlHelper html, string buttonText, string cssClass)
        {
            return string.Format("<input type=\"submit\" value=\"{0}\" class=\"{1}\"/>", buttonText, cssClass);
        }
    }
}