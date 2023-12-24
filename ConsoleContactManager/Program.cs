using ContactManeger;
using System;

class Program
{
    static void Main()
    {
        var contactManager = new ContactManager();

        try
        {
            // Adding contact groups
            contactManager.AddNewContactGroup("Family");
            contactManager.AddNewContactGroup("Work");
            contactManager.AddNewContactGroup("Friends");

            // Displaying existing contact groups
            Console.WriteLine("Existing contact groups:");
            foreach (var group in contactManager.ContactsGroup)
            {
                Console.WriteLine($"- {group}");
            }

            // Removing a contact group
            string groupToRemove = "Work"; // Group to remove
            contactManager.RemoveContactGroup(groupToRemove);

            Console.WriteLine($"'{groupToRemove}' contact group removed.");

            // Displaying updated list of contact groups
            Console.WriteLine("\nUpdated list of contact groups:");
            foreach (var group in contactManager.ContactsGroup)
            {
                Console.WriteLine($"- {group}");
            }

            // Visual separation
            Console.WriteLine("----------------------");

            // Adding new contacts
            contactManager.AddNewContact("John Doe", "john@example.com", "Family");
            contactManager.AddNewContact("Alice Smith", "alice@example.com", "Family");

            // Displaying contacts in a specific group
            string groupToDisplay = "Family";
            Console.WriteLine($"\nContacts in '{groupToDisplay}' group:");
            foreach (var contact in contactManager.GetContactsForGroupSortedByNameDescending(groupToDisplay))
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}");
            }

            // Removing a contact
            string emailToRemove = "john@example.com"; // Email to remove
            contactManager.RemoveContact(emailToRemove);

            Console.WriteLine($"\n'{emailToRemove}' contact removed.");

            // Displaying updated contacts in a specific group
            Console.WriteLine($"\nUpdated contacts in '{groupToDisplay}' group:");
            foreach (var contact in contactManager.GetContactsForGroupSortedByNameDescending(groupToDisplay))
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}");
            }

            // Visual separation
            Console.WriteLine("----------------------");

            // Adding contacts to favorites
            contactManager.AddContactToFavorites("alice@example.com");
            Console.WriteLine("\n'alice@example.com' added to favorites.");

            // Displaying updated contacts in a specific group
            Console.WriteLine($"\nUpdated contacts in '{groupToDisplay}' group:");
            foreach (var contact in contactManager.GetContactsForGroupSortedByNameDescending(groupToDisplay))
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Favorite: {contact.Favorite}");
            }

            // Removing contacts from favorites
            contactManager.RemoveContactFromFavorites("alice@example.com");
            Console.WriteLine("\n'alice@example.com' removed from favorites.");

            // Displaying updated contacts in a specific group
            Console.WriteLine($"\nUpdated contacts in '{groupToDisplay}' group:");
            foreach (var contact in contactManager.GetContactsForGroupSortedByNameDescending(groupToDisplay))
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Favorite: {contact.Favorite}");
            }

            // Visual separation
            Console.WriteLine("----------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}