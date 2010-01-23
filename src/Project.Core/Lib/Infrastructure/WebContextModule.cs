using System.Web;
using Ninject.Modules;

namespace Project.Core.Lib.Infrastructure
{
    public class WebContextModule : NinjectModule
    {
        private static IAppScope GetAppScope()
        {
            var ctx = new HttpContextWrapper(HttpContext.Current);
            return new HttpAppScope(ctx);
        }

        public override void Load()
        {
            Bind<IAppScope>().ToMethod(c => GetAppScope());
        }
    }
}
