using Core.Entities;
using Core.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GuardExtension
    {
        public static void NullPhoneBook(this IGuardClause guardClause, int phoneBookId, PhoneBook phoneBook)
        {
            if (phoneBook == null)
                throw new PhoneBookNotFoundException(phoneBookId);
        }

        public static void NullEntry(this IGuardClause guardClause, int entryId, Entry entry)
        {
            if (entry == null)
                throw new EntryNotFoundException(entryId);
        }
    }
}
