using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexchar.Documents;
using NexCharCore;

namespace NexChar.Services
{
    public class OrganizationService: ResourceService<OrganizationDocument>
    {

        public OrganizationService(IContextManager contextManager)
            : base(contextManager)
        {

        }

        public override OrganizationDocument Get(string modelID)
        {
            throw new NotImplementedException();
        }

        public OrganizationDocument Get(int modelID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<OrganizationDocument> GetAll()
        {
            throw new NotImplementedException();
        }

        public object CreateOrUpdate(OrganizationDocument doc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationDocument> GetFiltered(IReadOnlyCollection<KeyValuePair<string, string>> getQueryNameValuePairs)
        {
            throw new NotImplementedException();
        }
    }
}
