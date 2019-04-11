using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core.Entities
{
    public class Entry: BaseEntity
    {
        private PhoneBook _phoneBook;

        public Entry()
        {
        }

        private Entry(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Entry(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        private ILazyLoader LazyLoader { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public int PhoneBookId { get; set; }

        public PhoneBook PhoneBook
        {
            get => LazyLoader.Load(this, ref _phoneBook);
            set => _phoneBook = value;
        }
    }
}
