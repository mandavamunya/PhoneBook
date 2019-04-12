using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Core.Services
{
    public class EntryService : IEntryService
    {
        private readonly IAppLogger<EntryService> _logger;
        private readonly IAsyncRepository<Entry> _entryRepository;

        public EntryService(
            IAppLogger<EntryService> logger,
            IAsyncRepository<Entry> entryRepository
            )
        {
            _logger = logger;
            _entryRepository = entryRepository;
        }

        public async Task<Entry> AddEntryAsync(Entry entry)
        {
            return await _entryRepository.AddAsync(entry);
        }

        public async Task<int> DeleteEntryAsync(Entry entry)
        {
            return await _entryRepository.DeleteAsync(entry);
        }

        public async Task DeleteRangeEntryAsync(List<Entry> entries)
        {
            await _entryRepository.DeleteRangeAsync(entries);
        }

        public async Task<IEnumerable<Entry>> GetAllEntryItems(int entryId)
        {
            var spec = new EntryByIdSpecification(entryId);
            return await _entryRepository.ListAsync(spec);
        }

        public async Task<Entry> GetEntryById(int entryId)
        {
            var entry = await _entryRepository.GetByIdAsync(entryId);
            Guard.Against.NullEntry(entryId, entry);
            return entry;
        }

        public async Task<int> SetEntryAsync(Entry entry)
        {
            Guard.Against.Null(entry, nameof(entry));
            Guard.Against.NullEntry(entry.Id, entry);
            return await _entryRepository.UpdateAsync(entry);
        }
    }
}
