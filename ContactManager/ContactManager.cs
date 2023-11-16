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
    }
}
