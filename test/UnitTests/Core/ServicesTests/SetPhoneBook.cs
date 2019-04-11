using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using Xunit;

namespace UnitTests.Core.ServicesTests
{
    public class SetPhoneBook
    {
        private int _invalidId = -1;
        private Mock<IAsyncRepository<PhoneBook>> _mockPhoneBookRepo;

        public SetPhoneBook()
        {
            _mockPhoneBookRepo = new Mock<IAsyncRepository<PhoneBook>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidEntryId()
        {
            var phoneBookService = new PhoneBookService(null, _mockPhoneBookRepo.Object);

            await Assert.ThrowsAsync<PhoneBookNotFoundException>(
                async () => await phoneBookService.GetPhoneBookById(_invalidId)
            );
        }

        [Fact]
        public async void ThrowsGivenNullEntryServiceArguments()
        {
            var phoneBookService = new PhoneBookService(null, _mockPhoneBookRepo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await phoneBookService.SetPhoneBookAsync(null)
            );
        }
    }
}
