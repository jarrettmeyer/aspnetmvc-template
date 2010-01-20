using System.Web.Mvc;

namespace Project.Core
{
    public static class ExtensionsOfHtmlHelper
    {
        public const string CssPath = "~/Content/Stylesheets/";
        public const string JsPath = "~/Content/Scripts/";

        public static string IncludeCss(this HtmlHelper html, string css)
        {
            Ensure.ArgumentNotNullOrEmpty(css, "css");
            var fullPath = string.Concat(CssPath, css);
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);            
            var contentPath = urlHelper.Content(fullPath);
            return string.Format("<link rel=\"stylesheet\" type=\"text/css\" src=\"{0}\"/>", contentPath);
        }

        public static string IncludeJs(this HtmlHelper html, string js)
        {
            Ensure.ArgumentNotNull(js, "js");
            var fullPath = string.Concat(JsPath, js);
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);
            var contentPath = urlHelper.Content(fullPath);
            return string.Format("<script language=\"javascript\" type=\"text/javascript\" src=\"{0}\"></script>", contentPath);
        }
    }
}
