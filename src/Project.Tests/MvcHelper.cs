using System.Collections.Specialized;
using System.Web;
using System.Web.Routing;
using Moq;

namespace Project
{
    public class MvcHelper
    {
        public const string AppVirtualDirectory = "/myapp/";

        public HttpContextBase HttpContext
        {
            get
            {
                var httpContext = new Mock<HttpContextBase>();
                httpContext.Setup(c => c.Request).Returns(HttpRequest);
                httpContext.Setup(c => c.Response).Returns(HttpResponse);
                return httpContext.Object;
            }
        }

        public HttpRequestBase HttpRequest
        {
            get
            {
                var httpRequest = new Mock<HttpRequestBase>();
                httpRequest.Setup(r => r.ApplicationPath).Returns(AppVirtualDirectory);
                httpRequest.Setup(r => r.ServerVariables).Returns(new NameValueCollection());
                return httpRequest.Object;
            }
        }

        public HttpResponseBase HttpResponse
        {
            get
            {
                var httpResponse = new Mock<HttpResponseBase>();
                httpResponse.Setup(r => r.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);                
                return httpResponse.Object;
            }
        }

        public RequestContext RequestContext
        {
            get
            {
                return new RequestContext(HttpContext, new RouteData());
            }
        }        
    }
}
            