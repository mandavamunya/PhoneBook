using Core.Entities;
using Xunit;

namespace UnitTests.Core.EntitiesTests
{
    public class AddEntry
    {
        private string _name = "Jane Doe";
        private string _phoneNumber = "0738745352";
        
        [Fact]
        public void AddsEntityIfNotPresent()
        {
            var entry = new Entry(_name, _phoneNumber);
            Assert.Equal(_name, entry.Name);
            Assert.Equal(_phoneNumber, entry.PhoneNumber);
        }
    }
}
