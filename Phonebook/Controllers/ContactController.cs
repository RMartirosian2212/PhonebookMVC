using Microsoft.AspNetCore.Mvc;
using Phonebook.Models;
using Phonebook.Models.ViewModels;
using Phonebook.Repositories;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository<Contact, int> _contactRepository;
        public ContactController(IRepository<Contact, int> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index(string? name)
        {
            IEnumerable<Contact> contacts = _contactRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
            {
                contacts = contacts.Where(p => p.Name!.ToLower().Contains(name.ToLower()));
            }
            ContactViewModel viewModel = new ContactViewModel
            {
                contacts = contacts,
                Name = name
            };
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Insert(contact);
                _contactRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            _contactRepository.Update(contact);
            _contactRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _contactRepository.Delete(id);
            _contactRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
