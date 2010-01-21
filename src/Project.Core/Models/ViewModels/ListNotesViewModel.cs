using System.Collections.Generic;
using Project.Core.Models.Entities;

namespace Project.Core.Models.ViewModels
{
    public class ListNotesViewModel
    {
        public Contact Contact { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
