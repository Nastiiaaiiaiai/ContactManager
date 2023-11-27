
namespace TestContacts
{
    public class ContactManagerTests
    {
        // ���������� �������: �������� ��������� ������ ��������
        [Fact]
        public void AddNewContact_ValidContact_ContactAdded()
        {
            // Arrange
            var sut = new ContactManager();
            sut.AddNewContactGroup("Family");

            // Act
            sut.AddNewContact("John Doe", "john@example.com", "Family");

            // Assert
            Assert.Single(sut.Contacts); // ������� ���� ������� ���� ���������
        }

        // ���������� �������: �������� �� ������� � ������� ������������ ���������
        [Fact]
        public void AddNewContact_InvalidContact_ThrowArgumentException()
        {
            // Arrange
            var sut = new ContactManager();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.AddNewContact("", "", ""));
        }

        // ���������� �������: �������� ��������� ��������� ��������
        [Fact]
        public void RemoveContact_ExistingContact_ContactRemoved()
        {
            // Arrange
            var sut = new ContactManager();
            sut.AddNewContactGroup("Family");
            sut.AddNewContact("John Doe", "john@example.com", "Family");

            // Act
            sut.RemoveContact("john@example.com");

            // Assert
            Assert.Empty(sut.Contacts); // ϳ��� ��������� ������� ������ ������ ��������
        }

        // ���������� �������: �������� ������� � ������� ��������� �������� ��� ���������
        [Fact]
        public void RemoveContact_NonExistingContact_ThrowInvalidOperationException()
        {
            // Arrange
            var sut = new ContactManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.RemoveContact("nonexistent@example.com"));
        }
    }
}
