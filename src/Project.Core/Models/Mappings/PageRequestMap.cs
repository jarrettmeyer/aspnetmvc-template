using FluentNHibernate.Mapping;
using Project.Core.Models.Entities;

namespace Project.Core.Models.Mappings
{
    public class PageRequestMap : ClassMap<PageRequest>
    {
        public PageRequestMap()
        {
            Id(x => x.Id);
            Map(x => x.Path);
            Map(x => x.QueryString);
            Map(x => x.HttpMethod);
            Map(x => x.IsLocal);
            Map(x => x.IsSecure);
            Map(x => x.UserHostAddress);
            Map(x => x.UserHostName);
            Map(x => x.Browser);
            Map(x => x.BrowserId);
            Map(x => x.BrowserVersion);
            Map(x => x.Crawler);
            Map(x => x.IsMobile);
            Map(x => x.AllowJs);
            Map(x => x.Height);
            Map(x => x.Width);
            Map(x => x.Platform);
            Map(x => x.Time);
        }
    }
}
