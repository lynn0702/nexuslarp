using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexchar.Documents;
using NexCharCore;

namespace NexChar.Services
{
    public class CharacterService : ResourceService<CharacterDocument>
    {
        public CharacterService(IContextManager contextManager)
            : base(contextManager)
        {

        }

        public  CharacterDocument Get(int modelID)
        {
            throw new NotImplementedException();
        }

        public override CharacterDocument Get(string modelID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CharacterDocument> GetAll()
        {
            throw new NotImplementedException();
        }



        public IEnumerable<CharacterDocument> GetFiltered(IReadOnlyCollection<KeyValuePair<string, string>> readOnlyCollection)
        {
            throw new NotImplementedException();
        }

        public object CreateOrUpdate(SkillDocument doc)
        {
            throw new NotImplementedException();
        }
    }
}
