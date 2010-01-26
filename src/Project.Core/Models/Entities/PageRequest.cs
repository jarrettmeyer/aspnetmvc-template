using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace Project.Core.Models.Entities
{
    public class PageRequest
    {
        public virtual int Id { get; set; }
        public virtual string Path { get; set; }
        public virtual string QueryString { get; set; }
        public virtual string HttpMethod { get; set; }
        public virtual bool IsLocal { get; set; }
        public virtual bool IsSecure { get; set; }
        //public virtual string User { get; set; }
        public virtual string UserHostAddress { get; set; }
        public virtual string UserHostName { get; set; }
        public virtual string Browser { get; set; }
        public virtual string BrowserId { get; set; }
        public virtual string BrowserVersion { get; set; }
        public virtual bool Crawler { get; set; }
        public virtual bool IsMobile { get; set; }
        public virtual bool AllowJs { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual string Platform { get; set; }
        public virtual DateTime Time { get; set; }

        private static string BuildQueryString(NameValueCollection collection)
        {
            var parts = new List<string>();
            foreach (var key in collection.Keys)
            {
                parts.Add(string.Format("{0}={1}", key, collection[key.ToString()]));
            }
            return string.Join(Environment.NewLine, parts.ToArray());
        }

        public static PageRequest Create(HttpRequestBase request)
        {
            var pageRequest = new PageRequest();
            pageRequest.Path = request.Path;
            pageRequest.QueryString = BuildQueryString(request.QueryString);
            pageRequest.HttpMethod = request.HttpMethod;
            pageRequest.IsLocal = request.IsLocal;
            pageRequest.IsSecure = request.IsSecureConnection;
            //pageRequest.User = string.Empty;
            pageRequest.UserHostAddress = request.UserHostAddress;
            pageRequest.UserHostName = request.UserHostName;
            pageRequest.Browser = request.Browser.Browser;
            pageRequest.BrowserId = request.Browser.Id;
            pageRequest.BrowserVersion = request.Browser.Version;
            pageRequest.Crawler = request.Browser.Crawler;
            pageRequest.IsMobile = request.Browser.IsMobileDevice;
            pageRequest.AllowJs = request.Browser.SupportsXmlHttp;
            pageRequest.Height = request.Browser.ScreenPixelsHeight;
            pageRequest.Width = request.Browser.ScreenPixelsWidth;
            pageRequest.Platform = request.Browser.Platform;
            pageRequest.Time = DateTime.Now;
            return pageRequest;
        }

    }
}
