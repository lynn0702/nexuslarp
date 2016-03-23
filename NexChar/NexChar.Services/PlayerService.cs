using System;
using System.Collections.Generic;
using System.Linq;
using Nexchar.Documents;
using NexCharCore;
using NexCharCore.Models;

namespace NexChar.Services
{
    public class PlayerService : ResourceService<PlayerDocument>
    {

        public PlayerService(IContextManager contextManager)
            : base(contextManager)
        {

        }

        public override PlayerDocument Get(string modelID)
        {
            throw new NotImplementedException();
        }

        public PlayerDocument Get(int modelID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PlayerDocument> GetAll()
        {
            throw new NotImplementedException();
        }

        public object CreateOrUpdate(PlayerDocument doc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerDocument> GetFiltered(IReadOnlyCollection<KeyValuePair<string, string>> getQueryNameValuePairs)
        {
            throw new NotImplementedException();
        }
    }
}
