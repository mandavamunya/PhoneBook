using Core.Entities;

namespace Core.Specifications
{
    public class EntryByIdSpecification : BaseSpecification<Entry>
    {
        public EntryByIdSpecification(int entryId)
            : base(b => b.Id == entryId)
        {
        }
    }
}
