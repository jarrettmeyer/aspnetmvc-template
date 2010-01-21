using System.Web.Mvc;
using Moq;
using Xunit;

namespace Project.Core.Lib.Html
{
    public class ExtensionsOfHtmlHelperTests
    {
        [Fact]
        public void IncludeCssReturnsPathToStylesheet()
        {
            var viewContext = new ViewContext();
            viewContext.RequestContext = new MvcHelper().RequestContext;            
            var viewDataContainer = new Mock<IViewDataContainer>();            
            var htmlHelper = new HtmlHelper(viewContext, viewDataContainer.Object);
            var html = htmlHelper.IncludeCss("mystyle.css");
            Assert.NotNull(html);
            Assert.Contains("<link", html);
            Assert.Contains("rel=\"stylesheet\"", html);
            Assert.Contains("type=\"text/css\"", html);
            Assert.Contains("href=\"" + MvcHelper.AppVirtualDirectory + "Content/Stylesheets/mystyle.css\"", html);
            Assert.Contains("/>", html);
        }

        [Fact]
        public void IncludeJsReturnsPathToJavaScript()
        {
            var viewContext = new ViewContext();
            viewContext.RequestContext = new MvcHelper().RequestContext;
            var viewDataContainer = new Mock<IViewDataContainer>();
            var htmlHelper = new HtmlHelper(viewContext, viewDataContainer.Object);
            var html = htmlHelper.IncludeJs("application.js");
            Assert.NotNull(html);
            Assert.Contains("<script language=\"javascript\" type=\"text/javascript\"", html);
            Assert.Contains("src=\"" + MvcHelper.AppVirtualDirectory + "Content/Scripts/application.js\"", html);
            Assert.Contains("></script>", html);
        }
    }
}