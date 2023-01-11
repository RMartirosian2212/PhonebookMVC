namespace Phonebook.Models.ViewModels
{
    public class ContactViewModel
    {
        public IEnumerable<Contact> contacts { get; set; } = new List<Contact>();
        public string? Name { get; set; }
    }
}
