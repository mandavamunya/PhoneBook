using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEntryService
    {
        Task<Entry> GetEntryById(int entryId);
        Task <Entry> AddEntryAsync(Entry entry);
        Task <int> SetEntryAsync(Entry entry);
        Task <int> DeleteEntryAsync(Entry entry);
        Task DeleteRangeEntryAsync(List<Entry> entry);
    }
}
