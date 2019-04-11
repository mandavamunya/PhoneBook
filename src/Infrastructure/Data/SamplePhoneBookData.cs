using Core.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class SamplePhoneBookData
    {

        private static SamplePhoneBookData _instance;

        public static SamplePhoneBookData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SamplePhoneBookData();
                return _instance;
            }
        }

        public List<PhoneBook> PhoneBooks
        {
            get
            {
                return new List<PhoneBook>()
                {

                    new PhoneBook()
                    {
                        Name = "Business",
                        Entries = new List<Entry>()
                        {
                            new Entry()
                            {
                                Name = "John Doe",
                                PhoneNumber = "0837593263",
                            }, 
                            new Entry()
                            {
                                Name = "Dr D Simons",
                                PhoneNumber = "0210984675"
                            },
                            new Entry()
                            {
                                Name = "Prof. Marc Horne",
                                PhoneNumber = "0716573486"
                            }
                        }
                    },
                    new PhoneBook()
                    {
                        Name = "Family",
                        Entries = new List<Entry>()
                        {
                            new Entry()
                            {
                                Name = "Son",
                                PhoneNumber = "0616745678"
                            },
                            new Entry()
                            {
                                Name = "Wife",
                                PhoneNumber = "0636712657"
                            }
                        }
                    }

                };
            }
        }


    }
}
