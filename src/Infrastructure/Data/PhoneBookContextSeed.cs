using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PhoneBookContextSeed
    {
        private readonly PhoneBookContext _dbContext;

        public PhoneBookContextSeed(PhoneBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static async Task SeedPhoneBooksAsync(PhoneBookContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.PhoneBooks.Any())
                {
                    await dbContext.PhoneBooks.AddRangeAsync(SamplePhoneBookData.Instance.PhoneBooks);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<PhoneBookContextSeed>();
                    log.LogError(ex.Message);
                    await SeedPhoneBooksAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

    }
}
