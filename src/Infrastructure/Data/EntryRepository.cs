using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EntryRepository : EfRepository<Entry>, IEntryRepository
    {

        public EntryRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Entry> GetEntries()
        {
            return _dbContext.Entries.ToList();
        }

        public async Task<IEnumerable<Entry>> GetEntriesAsync()
        {
            return await _dbContext.Entries.ToListAsync();
        }

        public async Task<IEnumerable<Entry>> GetEntriesByPhoneBookId(int id)
        {
            var entries = await GetEntriesAsync();
            return entries.Where(entry => entry.PhoneBookId == id);
        }

        public async Task<Entry> GetEntryByName(string name)
        {
            var entries = await GetEntriesAsync();
            return entries.Where(entry => entry.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public async Task<Entry> GetEntryByPhoneNumber(string phoneNumber)
        {
            var entries = await GetEntriesAsync();
            return entries.Where(entry => entry.PhoneNumber.ToLower().Equals(phoneNumber.ToLower())).FirstOrDefault();
        }
    }
}
