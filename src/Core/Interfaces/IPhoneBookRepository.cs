using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhoneBookRepository
    {
        IEnumerable<PhoneBook> GetPhoneBooks();
        Task<IEnumerable<PhoneBook>> GetPhoneBooksAsync();
        Task<PhoneBook> GetPhoneBookByName(string name);
    }
}
