using System.Web.Mvc;
using Project.Core.Lib.Data;
using Project.Core.Lib.Infrastructure;
using Project.Core.Models.Entities;

namespace Project.Core.Lib.ActionFilters
{
    public class LogRequestsAttribute : ActionFilterAttribute
    {
        private IRepository _repository;

        public IRepository Repository
        {
            get
            {
                return _repository ?? (_repository = ServiceLocator.Resolve<IRepository>());
            }
            set
            {
                _repository = value;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var pageRequest = PageRequest.Create(filterContext.HttpContext.Request);
            Repository.Insert(pageRequest);
        }
    }
}
