using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Web
{
    public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
    {
        public PhoneBookContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>();
            optionsBuilder.UseSqlServer("Data Source=phonebook.db");

            return new PhoneBookContext(optionsBuilder.Options);
        }
    }
}
