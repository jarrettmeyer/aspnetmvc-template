using FluentNHibernate.Mapping;

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
