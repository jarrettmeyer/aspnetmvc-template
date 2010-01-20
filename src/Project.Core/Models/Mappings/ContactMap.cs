using FluentNHibernate.Mapping;

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
            HasMany(x => x.Notes);
        }
    }
}
