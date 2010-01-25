using System.Web.Mvc;
using Project.Core.Lib.Data;
using Project.Core.Lib.Infrastructure;
using Project.Core.Models.Entities;

namespace Project.Core.Controllers
{
    public class ContactsController : ApplicationController
    {        
        private readonly IRepository _repository;

        public ContactsController(IRepository repository, IAppScope appScope)            
            : base(appScope)
        {
            Ensure.ArgumentNotNull(repository, "repository");            
            _repository = repository;            
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            _repository.Insert(contact);
            if (_appScope.IsXhr)
            {
                return PartialView("ShowPartial", contact);
            }
            _appScope.AddSuccess("Successfully created a new contact");
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Delete), ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var contact = _repository.FindById<Contact>(id);
            if (contact == null)
            {
                Log.BoundTo(this).WriteWarningMessage(string.Format("Attempted to delete contact with ID {0}", id));
                return Json(false);
            }
            _repository.Delete(contact);
            return Json(true);
        }

        public ActionResult Details(int id)
        {
            var contact = _repository.FindById<Contact>(id);
            return View(contact);
        }

        public ActionResult Edit(int id)
        {
            var contact = _repository.FindById<Contact>(id);
            return View(contact);
        }

        public ActionResult Index()
        {
            var contacts = _repository.FindAll<Contact>();
            return View(contacts);
        }

        public ActionResult New()
        {
            var contact = new Contact();
            return View(contact);
        }

        public ActionResult Show(int id)
        {
            var contact = _repository.FindById<Contact>(id);
            return View(contact);
        }

        [AcceptVerbs(HttpVerbs.Put), ValidateAntiForgeryToken]
        public ActionResult Update(int id, Contact contact)
        {
            var original = _repository.FindById<Contact>(id);
            original.EmailAddress = contact.EmailAddress;
            original.FirstName = contact.FirstName;
            original.LastName = contact.LastName;
            _repository.Commit();
            return RedirectToAction("Index");
        }
    }
}
