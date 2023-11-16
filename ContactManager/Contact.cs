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
        public bool Favoriete { get; set; }

        private Contact() { }

        public Contact(string name, string contactgroup, string email, bool favoriete) : this()
        {
            Name = name;
            ContactGroup = contactgroup;
            Email = email;
            Favoriete = favoriete;
        }
        public Contact(string name, string contactgroup, string email) : this()
        {
            Name = name;
            ContactGroup = contactgroup;
            Email = email;
            Favoriete = false;
        }
    }
}
