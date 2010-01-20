using System;

namespace Project.Core.Models
{
    public class Note
    {
        public virtual int Id { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual string NoteText { get; set; }
        public virtual DateTime DateAdded { get; set; }
    }
}
