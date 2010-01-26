using System.Web.Mvc;
using Project.Core.Lib.ActionFilters;
using Project.Core.Lib.Infrastructure;

namespace Project.Core.Controllers
{
    [HandleErrorWithElmah, LogRequests]
    public class ApplicationController : Controller
    {
        protected readonly IAppScope _appScope;

        public ApplicationController(IAppScope appScope)
        {
            _appScope = appScope;
            CreateController();
        }

        private void CreateController()
        {
            OnControllerCreated();
        }

        protected virtual void OnControllerCreated()
        {
            if (_appScope.IsNewSession)
            {
                _appScope.AddInfo("Welcome. This appears to be your first visit!");
            }
            _appScope.AddWarning("This site is currently being developed. Proceed with caution.");
        }
    }
}
