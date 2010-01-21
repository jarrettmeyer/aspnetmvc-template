using FluentNHibernate.Mapping;
using Project.Core.Models.Entities;

namespace Project.Core.Models.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.EmailAddress);
            HasMany(x => x.Notes).Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
