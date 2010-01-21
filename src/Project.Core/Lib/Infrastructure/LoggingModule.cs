using Ninject.Modules;

namespace Project.Core.Lib.Infrastructure
{
    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().ToMethod(c => new Log4NetLogger(c.Request.ParentContext.Plan.Type));
        }
    }
}
