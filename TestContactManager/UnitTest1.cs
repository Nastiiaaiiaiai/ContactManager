namespace TestContactManager
{
    public class UnitTest1
    {
        //AddNewContactGroup

        [Fact]
        public void AddNewContactGroup_CorrectString_ContactGroupAdded()
        {
            //arrange
            string contactgroup = "Family";
            var sut = new ContactManager();
            //act
            sut.AddNewContactGroup(contactgroup);
            //assert
            Assert.Contains<string>(contactgroup, sut.ContactsGroup);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AddNewContactGroup_WrongArgument_ThrowArgumentExeption(string contactgroup)
        {
            var sut = new ContactManager();
            //act and assert
            Assert.Throws<ArgumentException>(() => sut.AddNewContactGroup(contactgroup));
        }

        [Fact]
        public void AddNewContactGroup_TwoSimilarString_ThrowWrongOperationException()
        {
            //arrange
            string contactgroup = "Family";
            var sut = new ContactManager();
            //act
            sut.AddNewContactGroup(contactgroup);
            //act and assert
            Assert.Throws<InvalidOperationException>(() => sut.AddNewContactGroup(contactgroup));
        }

        //RemoveContactGroup

        [Fact]
        public void RemoveContactGroup_CorrectString_ContactGroupRemoved()
        {
            //arrange
            string contactgroup = "Family";
            var sut = new ContactManager();
            sut.AddNewContactGroup(contactgroup);
            //act
            sut.RemoveContactGroup(contactgroup);
            //assert
            Assert.DoesNotContain<string>(contactgroup, sut.ContactsGroup);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RemoveContactGroup_WrongArgument_ThrowArgumentExeption(string contactgroup)
        {
            var sut = new ContactManager();
            //act and assert
            Assert.Throws<ArgumentException>(() => sut.RemoveContactGroup(contactgroup));
        }

        [Fact]
        public void RemoveContactGroup_NotExistContactGroupAndEmptyList_ThrowWrongOperationException()
        {
            //arrange
            string contactgroup = "Family";
            var sut = new ContactManager();
            //act and assert
            Assert.Throws<InvalidOperationException>(() => sut.RemoveContactGroup(contactgroup));
        }

        [Fact]
        public void RemoveContactGroup_NotExistContactGroupAndFilledList_ThrowWrongOperationException()
        {
            //arrange
            string[] contactsgroup = { "Friends", "Relatives", "Colleges" };
            string contactgroup_friends = "Family";
            var sut = new ContactManager();
            foreach (var contactgroup in contactsgroup)
            {
                sut.AddNewContactGroup(contactgroup);
            }
            //act and assert
            Assert.Throws<InvalidOperationException>(() => sut.RemoveContactGroup(contactgroup_friends));
        }
    }
}