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

            // Visual separation
            Console.WriteLine("----------------------");

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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}