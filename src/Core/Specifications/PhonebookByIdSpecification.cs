using Core.Entities;

namespace Core.Specifications
{
    public class PhonebookByIdSpecification: BaseSpecification<PhoneBook>
    {
        public PhonebookByIdSpecification(int phoneBookId)
            : base(b => b.Id == phoneBookId)
        {
            AddInclude(b => b.Entries);
        }
    }
}
