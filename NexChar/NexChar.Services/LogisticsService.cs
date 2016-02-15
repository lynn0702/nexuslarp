using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexchar.Documents;
using NexCharCore;

namespace NexChar.Services
{
    public class LogisticsService : ResourceService<LogisticsDocument>
    {
        public LogisticsService(IContextManager contextManager) : base(contextManager)
        {
        }

        public override LogisticsDocument Get(string modelID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<LogisticsDocument> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
