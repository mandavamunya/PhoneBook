using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Core.SpecificationsTests
{
    public class PhoneBookByIdSpecificationTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 0)]
        public void MatchesExpectedNumberOfItems(int phoneBookId, int expectedCount)
        {
            var spec = new PhonebookByIdSpecification(phoneBookId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<PhoneBook> GetTestItemCollection()
        {
            return new List<PhoneBook>()
            {
                new PhoneBook() { Id=1, Name = "Family" },
                new PhoneBook() { Id=2, Name = "Friend" },
                new PhoneBook() { Id=3, Name = "Business" }
            };
        }
    }
}
