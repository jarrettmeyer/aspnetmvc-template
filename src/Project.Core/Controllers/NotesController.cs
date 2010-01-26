using System;
using System.Web.Mvc;
using Project.Core.Lib.Data;
using Project.Core.Lib.Infrastructure;
using Project.Core.Models.Entities;
using Project.Core.Models.ViewModels;

namespace Project.Core.Controllers
{
    public class NotesController : ApplicationController
    {        
        private readonly IRepository _repository;

        public NotesController(IRepository repository, IAppScope appScope)       
            : base(appScope)
        {
            Ensure.ArgumentNotNull(repository, "repository");
            _repository = repository;            
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken]
        public ActionResult Create(int contactId, Note note)
        {
            var contact = _repository.FindById<Contact>(contactId);
            note.DateAdded = DateTime.Now;
            contact.AddNote(note);
            _repository.Commit();
            _appScope.AddSuccess(string.Format("Note was successfully created for {0}", contact.EmailAddress));
            return RedirectToAction("Index", new { contactId });
        }

        [AcceptVerbs(HttpVerbs.Delete), ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var note = _repository.FindById<Note>(id);            
            _repository.Delete(note);
            _appScope.AddSuccess("Note was successfully deleted.");
            return Json(true);            
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

        [AcceptVerbs(HttpVerbs.Put), ValidateAntiForgeryToken]
        public ActionResult Update(int id, Note note)
        {
            var original = _repository.FindById<Note>(id);            
            original.NoteText = note.NoteText;
            _repository.Commit();
            _appScope.AddSuccess("Note was successfully updated.");
            return new EmptyResult();
        }
    }
}
