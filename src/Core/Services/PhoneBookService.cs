using Ardalis.GuardClauses;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IAppLogger<PhoneBookService> _logger;
        private readonly IAsyncRepository<PhoneBook> _phoneBookRepository;
        private readonly IAsyncRepository<Entry> _entryRepository;

        public PhoneBookService(
            IAppLogger<PhoneBookService> logger,
            IAsyncRepository<PhoneBook> phoneBookRepository,
            IAsyncRepository<Entry> entryRepository
            )
        {
            _logger = logger;
            _phoneBookRepository = phoneBookRepository;
            _entryRepository = entryRepository;
        }

        public async Task<PhoneBook> AddPhoneBookAsync(PhoneBook phoneBook)
        {
            return await _phoneBookRepository.AddAsync(phoneBook);
        }

        public async Task<int> DeletePhoneBookAsync(PhoneBook phoneBook)
        {
            var entries = phoneBook.Entries;

            if (entries != null)
                await _entryRepository.DeleteRangeAsync(entries);

            return await _phoneBookRepository.DeleteAsync(phoneBook);
        }

        public async Task DeleteRangePhoneBookAsync(List<PhoneBook> phoneBooks)
        {
            foreach (var phoneBook in phoneBooks)
            {
                var entries = phoneBook.Entries;
                if (entries != null)
                    await _entryRepository.DeleteRangeAsync(entries);
            }
            await _phoneBookRepository.DeleteRangeAsync(phoneBooks);
        }

        public async Task<IEnumerable<PhoneBook>> GetAllPhoneBookItems(int phoneBookId)
        {
            var spec = new PhonebookByIdSpecification(phoneBookId);
            return await _phoneBookRepository.ListAsync(spec);
        }

        public async Task<IEnumerable<PhoneBook>> GetAllPhoneBooks()
        {
            return await _phoneBookRepository.ListAllAsync();
        }

        public async Task<PhoneBook> GetPhoneBookById(int phoneBookId)
        {
            var phoneBook = await _phoneBookRepository.GetByIdAsync(phoneBookId);
            Guard.Against.NullPhoneBook(phoneBookId, phoneBook);
            return phoneBook;
        }

        public async Task<int> SetPhoneBookAsync(PhoneBook phoneBook)
        {
            Guard.Against.Null(phoneBook, nameof(phoneBook));
            Guard.Against.NullPhoneBook(phoneBook.Id, phoneBook);
            return await _phoneBookRepository.UpdateAsync(phoneBook);
        }
    }
}
