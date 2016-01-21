using System.Data.Entity.Core.Objects;

namespace NexCharCore
{
 public interface IAuditable
    {

        void Audit(ObjectContext context, ObjectStateEntry entry, string currentUser);
    
    }
}
