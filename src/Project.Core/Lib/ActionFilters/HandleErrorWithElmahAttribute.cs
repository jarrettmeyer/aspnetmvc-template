using System;
using System.Web.Mvc;
using Elmah;

namespace Project.Core.Lib.ActionFilters
{
    public class HandleErrorWithElmahAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (context.ExceptionHandled)
            {
                RaiseErrorSignal(context.Exception);
            }
        }

        private static void RaiseErrorSignal(Exception e)
        {
            var context = System.Web.HttpContext.Current;
            ErrorSignal.FromContext(context).Raise(e, context);
        }
    }
}
