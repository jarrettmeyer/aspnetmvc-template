using FluentNHibernate.Mapping;
using Project.Core.Models.Entities;

namespace Project.Core.Models.Mappings
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Id(x => x.Id);
            Map(x => x.NoteText);
            Map(x => x.DateAdded);
            References(x => x.Contact);
        }
    }
}
