namespace TestFavoriteSorts
{
    public class ContactManagerTests
    {
        [Fact]
        public void GetFavoritesSortedByNameDescending_ReturnsSortedFavoritesList()
        {
            // Arrange
            var contactManager = new ContactManager();
            contactManager.AddNewContactGroup("Friends");
            contactManager.AddNewContact("John", "john@example.com", "Friends");
            contactManager.AddNewContact("Alice", "alice@example.com", "Friends");

            contactManager.AddContactToFavorites("john@example.com");
            contactManager.AddContactToFavorites("alice@example.com");

            // Act
            var sortedFavorites = contactManager.GetFavoritesSortedByNameDescending();

            // Assert
            Assert.Collection(sortedFavorites,
                contact => Assert.Equal("John", contact.Name),
                contact => Assert.Equal("Alice", contact.Name)
            );
        }

        [Fact]
        public void GetFavoritesSortedByNameDescending_EmptyFavoritesList_ReturnsEmptyList()
        {
            // Arrange
            var contactManager = new ContactManager();

            // Act
            var sortedFavorites = contactManager.GetFavoritesSortedByNameDescending();

            // Assert
            Assert.Empty(sortedFavorites);
        }
    }
}