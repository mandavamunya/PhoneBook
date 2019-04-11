using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEntryRepository
    {
        IEnumerable<Entry> GetEntries();
        Task<IEnumerable<Entry>> GetEntriesAsync();
        Task<Entry> GetEntryByName(string name);
        Task<Entry> GetEntryByPhoneNumber(string phoneNumber);
        Task<IEnumerable<Entry>> GetEntriesByPhoneBookId(int id);
    }
}
