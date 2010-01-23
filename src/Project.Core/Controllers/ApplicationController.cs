using System.Web.Mvc;
using Project.Core.Lib.Infrastructure;

namespace Project.Core.Controllers
{
    public class ApplicationController : Controller
    {
        protected IAppScope _appScope;

        public ApplicationController(IAppScope appScope)
        {
            _appScope = appScope;
        }
    }
}
