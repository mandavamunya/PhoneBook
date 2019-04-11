using Core.Entities;
using Xunit;

namespace UnitTests.Core.EntitiesTests
{
    public class AddPhoneBook
    {
        private string _name = "Friends";

        [Fact]
        public void AddsEntityIfNotPresent()
        {
            var phoneBook = new PhoneBook(_name);
            Assert.Equal(_name, phoneBook.Name);
        }
    }
}
