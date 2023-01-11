using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Repositories
{
    public class ContactRepository : IRepository<Contact, int>
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Contact> GetAll()
        {
            return _db.Contacts;
        }
        public Contact GetById(int id)
        {
            return _db.Contacts.Find(id);
        }
        public void Insert(Contact enitity)
        {
            _db.Contacts.Add(enitity);
        }
        public void Update(Contact enitity)
        {
            _db.Contacts.Update(enitity);
        }
        public void Delete(int id)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
