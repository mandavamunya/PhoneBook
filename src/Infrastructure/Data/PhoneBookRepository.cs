using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PhoneBookRepository : EfRepository<PhoneBook>, IPhoneBookRepository
    {

        public PhoneBookRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public async Task<PhoneBook> GetPhoneBookByName(string name)
        {
            var phoneBooks = await GetPhoneBooksAsync();
            return phoneBooks.Where(phoneBook => phoneBook.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            return _dbContext.PhoneBooks
                .Include(o => o.Entries)
                .ToList();
        }

        public async Task<IEnumerable<PhoneBook>> GetPhoneBooksAsync()
        {
            return await _dbContext.PhoneBooks
                .Include(o => o.Entries)
                .ToListAsync();
        }

    }
}
