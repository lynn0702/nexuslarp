using System.Collections.Generic;
using Nexchar.Documents;

namespace NexChar.Services
{
    public interface IBasicDocumentService<T>
     where T : class, IDocument, new()
    {
        T Get(string modelID);
        IEnumerable<T> GetAll();
    }
}
