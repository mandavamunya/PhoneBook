using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Core.Entities
{
    public class PhoneBook: BaseEntity
    {
        private ICollection<Entry> _entries;

        public PhoneBook()
        {
        }

        private PhoneBook(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public PhoneBook(string name)
        {
            Name = name;
        }

        private ILazyLoader LazyLoader { get; set; }

        public string Name { get; set; }

        public ICollection<Entry> Entries
        {
            get => LazyLoader.Load(this, ref _entries);
            set => _entries = value;
        }
    }
}
