namespace Project.Core.Lib.Infrastructure
{
    /// <summary>
    /// Provides an application level wrapper for resources. Allows for a separation
    /// from other intrinsic objects such as HttpContext, HttpRequest, HttpSessionState,
    /// Caching, etc. Undoing the binding between your business objects and those
    /// Framework objects makes for very difficult testing.
    /// </summary>
    public interface IAppScope
    {
        bool IsXhr { get; }
    }
}
