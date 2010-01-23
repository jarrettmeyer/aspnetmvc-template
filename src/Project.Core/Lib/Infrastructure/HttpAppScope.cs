using System.Web;
using System.Web.Mvc;

namespace Project.Core.Lib.Infrastructure
{
    public class HttpAppScope : IAppScope
    {
        private readonly HttpContextBase _httpContext;

        public HttpAppScope(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public bool IsXhr
        {
            get { return _httpContext.Request.IsAjaxRequest(); }
        }
    }
}
