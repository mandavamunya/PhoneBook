using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using Xunit;

namespace UnitTests.Core.ServicesTests
{
    public class SetEntry
    {

        private int _invalidId = -1;
        private Mock<IAsyncRepository<Entry>> _mockEntryRepo;

        public SetEntry()
        {
            _mockEntryRepo = new Mock<IAsyncRepository<Entry>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidEntryId()
        {
            var entryService = new EntryService(null, _mockEntryRepo.Object);

            await Assert.ThrowsAsync<EntryNotFoundException>(
                async () => await entryService.GetEntryById(_invalidId)
            );
        }

        [Fact]
        public async void ThrowsGivenNullEntryServiceArguments()
        {
            var entryService = new EntryService(null, _mockEntryRepo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await entryService.SetEntryAsync(null)
            );
        }

    }
}
