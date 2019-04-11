using Core.Entities;
using Infrastructure.Data;

namespace IntegrationTests.Builders
{
    public class PhoneBookBuilder
    {
        private static PhoneBookBuilder _instance;
        public static PhoneBookBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PhoneBookBuilder();
                }
                return _instance;
            }
        }

        public PhoneBook DummyPhoneBook()
        {
            return SamplePhoneBookData.Instance.PhoneBooks[0];
        }
    }
}
