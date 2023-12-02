using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManeger
{
    public class ContactManager
    {
        public List<Contact> Contacts { get; }

        public List<string> ContactsGroup { get; }

        public ContactManager()
        {
            Contacts = new List<Contact>();
            ContactsGroup = new List<string>();
        }

        public void AddNewContactGroup(string contactgroup)
        {
            if (contactgroup == null || contactgroup.Length == 0)
                throw new ArgumentException(contactgroup);
            if (ContactsGroup.Contains(contactgroup))
                throw new InvalidOperationException("This contact group is already in place!");

            ContactsGroup.Add(contactgroup);
        }

        public void RemoveContactGroup(string contactgroup)
        {
            if (contactgroup == null || contactgroup.Length == 0)
                throw new ArgumentException(contactgroup);
            if (!ContactsGroup.Remove(contactgroup))
                throw new InvalidOperationException("There is NO such contact group!");
        }

        public void AddNewContact(string name, string email, string contactGroup)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contactGroup))
                throw new ArgumentException("Name, email, and contact group cannot be empty");

            if (!ContactsGroup.Contains(contactGroup))
                throw new InvalidOperationException("Contact group does not exist");

            // Перевірка на наявність контакту з такою ж електронною адресою
            if (Contacts.Any(c => c.Email == email))
                throw new InvalidOperationException("Contact with this email already exists");

            var newContact = new Contact(name, contactGroup, email);
            Contacts.Add(newContact);
        }

        public void RemoveContact(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be empty");

            var contactToRemove = Contacts.FirstOrDefault(c => c.Email == email);
            if (contactToRemove == null)
                throw new InvalidOperationException("Contact with this email does not exist");

            Contacts.Remove(contactToRemove);
        }

        public void AddContactToFavorites(string email)
        {
            var contact = Contacts.FirstOrDefault(c => c.Email == email);
            if (contact == null)
                throw new InvalidOperationException("Contact with this email does not exist");

            contact.AddToFavorites();
        }

        public void RemoveContactFromFavorites(string email)
        {
            var contact = Contacts.FirstOrDefault(c => c.Email == email);
            if (contact == null)
                throw new InvalidOperationException("Contact with this email does not exist");

            contact.RemoveFromFavorites();
        }

        public IEnumerable<Contact> GetFavoritesSortedByNameDescending()
        {
            var favoriteContacts = Contacts.Where(c => c.Favorite).OrderByDescending(c => c.Name);
            return favoriteContacts;
        }
    }

}
