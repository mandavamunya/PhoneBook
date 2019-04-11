using Infrastructure.Data;
using IntegrationTests.Builders;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories.PhoneBookRepositoryTests
{
    public class GetById
    {
        private readonly PhoneBookContext _phoneBookContext;
        private readonly PhoneBookRepository _phoneBookRepository;

        private readonly ITestOutputHelper _output;

        public GetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<PhoneBookContext>()
                .UseInMemoryDatabase(databaseName: "TestPhoneBook")
                .Options;
            _phoneBookContext = new PhoneBookContext(dbOptions);
            _phoneBookRepository = new PhoneBookRepository(_phoneBookContext);
        }

        [Fact]
        public void GetsExistingPhoneBook()
        {
            var dummyPhoneBook = PhoneBookBuilder.Instance.DummyPhoneBook();
            _phoneBookContext.PhoneBooks.Add(dummyPhoneBook);
            _phoneBookContext.SaveChanges();
            int phoneBookId = dummyPhoneBook.Id;
            _output.WriteLine($"PhoneBookId: {phoneBookId}");

            var phoneBookFromRepo = _phoneBookRepository.GetById(phoneBookId);
            Assert.Equal(dummyPhoneBook.Id, phoneBookFromRepo.Id);
        }
    }
}
