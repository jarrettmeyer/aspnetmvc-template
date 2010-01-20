using System.Collections.Generic;

namespace Project.Core.Models
{
    public class Contact
    {
        public Contact()
        {
            Notes = new List<Note>();
        }

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual IList<Note> Notes { get; private set; }

        public virtual void AddNote(Note note)
        {
            Notes.Add(note);
        }

        public virtual void RemoveNote(Note note)
        {
            Notes.Remove(note);
        }
    }
}
