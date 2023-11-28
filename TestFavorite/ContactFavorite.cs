namespace TestFavorite
{
    public class ContactFavorite
    {
        [Fact]
        public void AddContactToFavorites_ExistingContact_AddedToFavorites()
        {
            // Arrange
            var sut = new ContactManager();
            sut.AddNewContactGroup("Family");
            sut.AddNewContact("John Doe", "john@example.com", "Family");

            // Act
            sut.AddContactToFavorites("john@example.com");

            // Assert
            var contact = sut.Contacts.FirstOrDefault(c => c.Email == "john@example.com");
            Assert.True(contact?.Favorite);
        }

        [Fact]
        public void RemoveContactFromFavorites_ExistingFavoriteContact_RemovedFromFavorites()
        {
            // Arrange
            var sut = new ContactManager();
            sut.AddNewContactGroup("Family");
            sut.AddNewContact("John Doe", "john@example.com", "Family");
            sut.AddContactToFavorites("john@example.com");

            // Act
            sut.RemoveContactFromFavorites("john@example.com");

            // Assert
            var contact = sut.Contacts.FirstOrDefault(c => c.Email == "john@example.com");
            Assert.False(contact?.Favorite);
        }

        [Fact]
        public void AddContactToFavorites_NonExistingContact_ThrowInvalidOperationException()
        {
            // Arrange
            var sut = new ContactManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.AddContactToFavorites("nonexistent@example.com"));
        }

        [Fact]
        public void RemoveContactFromFavorites_NonExistingContact_ThrowInvalidOperationException()
        {
            // Arrange
            var sut = new ContactManager();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.RemoveContactFromFavorites("nonexistent@example.com"));
        }
    }
}