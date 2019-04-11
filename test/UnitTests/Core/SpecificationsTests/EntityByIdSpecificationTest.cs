using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Core.SpecificationsTests
{
    public class EntityByIdSpecificationTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 0)]
        public void MatchesExpectedNumberOfItems(int phoneBookId, int expectedCount)
        {
            var spec = new EntryByIdSpecification(phoneBookId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Entry> GetTestItemCollection()
        {
            return new List<Entry>()
            {
                new Entry() { Id=1, Name = "Son", PhoneNumber = "0217436876" },
                new Entry() { Id=2, Name = "John", PhoneNumber = "0736578937" },
                new Entry() { Id=3, Name = "David", PhoneNumber = "0816572876" }
            };
        }
    }
}
