namespace Project.Core.Lib.Infrastructure
{
    public static class Log
    {
        public static ILogger BoundTo<T>()
        {
            return new Log4NetLogger(typeof(T));
        }

        public static ILogger BoundTo(object source)
        {
            Ensure.ArgumentNotNull(source, "source");
            return new Log4NetLogger(source.GetType());
        }
    }
}
