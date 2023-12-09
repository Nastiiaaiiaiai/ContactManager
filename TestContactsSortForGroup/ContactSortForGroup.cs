using System;
using Xunit;
using ContactManeger;

namespace TestContactsSortForGroup
{
    public class ContactSortForGroup
    {
        // ���� �� ��������� ������������� ������ �������� ��� ������ �����
        [Fact]
        public void GetContactsForGroupSortedByNameDescending_ValidGroup_ReturnsSortedContacts()
        {
            // Arrange
            var manager = new ContactManager();
            manager.AddNewContactGroup("Friends");
            manager.AddNewContact("John", "john@example.com", "Friends");
            manager.AddNewContact("Alice", "alice@example.com", "Friends");

            // Act
            var sortedContacts = manager.GetContactsForGroupSortedByNameDescending("Friends").ToList();

            // Assert
            Assert.Equal(2, sortedContacts.Count);
            Assert.Equal("John", sortedContacts[0].Name);
            Assert.Equal("Alice", sortedContacts[1].Name);
        }

        // ���� �� ���������� ���������� ������ �������� ��� �������� �����
        [Fact]
        public void GetContactsForGroupSortedByNameDescending_EmptyGroup_ReturnsEmptyList()
        {
            // Arrange
            var manager = new ContactManager();
            manager.AddNewContactGroup("Family");

            // Act
            var sortedContacts = manager.GetContactsForGroupSortedByNameDescending("Family").ToList();

            // Assert
            Assert.Empty(sortedContacts);
        }

        // ���� �� ���������� ������ �������� ��� ����� � ����� ���������
        [Fact]
        public void GetContactsForGroupSortedByNameDescending_GroupWithSingleContact_ReturnsSingleContact()
        {
            // Arrange
            var manager = new ContactManager();
            manager.AddNewContactGroup("Colleagues");
            manager.AddNewContact("Emma", "emma@example.com", "Colleagues");

            // Act
            var sortedContacts = manager.GetContactsForGroupSortedByNameDescending("Colleagues").ToList();

            // Assert
            Assert.Single(sortedContacts);
            Assert.Equal("Emma", sortedContacts[0].Name);
        }

        // ���� �� ������ ���������� ��� ������ �����
        [Fact]
        public void GetContactsForGroupSortedByNameDescending_NonExistentGroup_ThrowsException()
        {
            // Arrange
            var manager = new ContactManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => manager.GetContactsForGroupSortedByNameDescending("NonExistentGroup"));
        }
    }
}