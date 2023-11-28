using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManeger
{
    public class Contact
    {
        public string Name { get; }
        public string ContactGroup { get; }
        public string Email { get; }
        public bool Favorite { get; private set; }

        public Contact(string name, string contactgroup, string email, bool favorite = false)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactgroup) || string.IsNullOrEmpty(email))
                throw new ArgumentException("Name, contact group, and email cannot be empty");

            Name = name;
            ContactGroup = contactgroup;
            Email = email;
            Favorite = favorite;
        }

        public void AddToFavorites()
        {
            Favorite = true;
        }

        public void RemoveFromFavorites()
        {
            Favorite = false;
        }
    }
}
