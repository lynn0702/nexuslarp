using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexchar.Documents;
using NexCharCore;

namespace NexChar.Services
{
    public abstract class ResourceService<T> : IBasicDocumentService<T> where T : class,IDocument, new()
    {
        protected ResourceService(IContextManager contextManager)
        {
            _nexCharContext = contextManager.NexCharContext;
        }

        internal NexCharContextBase _nexCharContext;
        public abstract T Get(string modelID);
        public abstract IEnumerable<T> GetAll();

    }
}
