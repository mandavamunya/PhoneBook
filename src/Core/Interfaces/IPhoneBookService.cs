using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhoneBookService
    {
        Task<IEnumerable<PhoneBook>> GetAllPhoneBooks();
        Task<IEnumerable<PhoneBook>> GetAllPhoneBookItems(int phoneBookId);
        Task<PhoneBook> GetPhoneBookById(int phoneBookId);
        Task<PhoneBook> AddPhoneBookAsync(PhoneBook phoneBook);
        Task<int> SetPhoneBookAsync(PhoneBook phoneBook);
        Task<int> DeletePhoneBookAsync(PhoneBook phoneBook);
        Task DeleteRangePhoneBookAsync(List<PhoneBook> phoneBook);
    }
}
