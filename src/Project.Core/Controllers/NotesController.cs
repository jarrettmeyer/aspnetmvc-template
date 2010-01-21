using System;
using System.Web.Mvc;
using Project.Core.Lib.Data;
using Project.Core.Models.Entities;
using Project.Core.Models.ViewModels;

namespace Project.Core.Controllers
{
    public class NotesController : ApplicationController
    {
        private readonly IRepository _repository;

        public NotesController(IRepository repository)
        {
            Ensure.ArgumentNotNull(repository, "repository");
            _repository = repository;
        }

        public ActionResult Create(int contactId, Note note)
        {
            var contact = _repository.FindById<Contact>(contactId);
            note.DateAdded = DateTime.Now;
            contact.AddNote(note);
            _repository.Commit();
            return RedirectToAction("Index", new { contactId });
        }

        public ActionResult Delete(int id)
        {
            var note = _repository.FindById<Note>(id);            
            _repository.Delete(note);
            return new EmptyResult();
        }

        public ActionResult Edit(int id)
        {
            var note = _repository.FindById<Note>(id);
            return View(note);
        }

        public ActionResult Index(int contactId)
        {
            var contact = _repository.FindById<Contact>(contactId);
            var notes = contact.Notes;
            return View(new ListNotesViewModel { Contact = contact, Notes = notes });
        }
        
        public ActionResult New(int contactId)
        {
            var note = new Note();
            return View(note);
        }

        public ActionResult Show(int id)
        {
            var note = _repository.FindById<Note>(id);
            return View(note);
        }

        public ActionResult Update(int id, Note note)
        {
            var original = _repository.FindById<Note>(id);            
            original.NoteText = note.NoteText;
            _repository.Commit();
            return new EmptyResult();
        }
    }
}
