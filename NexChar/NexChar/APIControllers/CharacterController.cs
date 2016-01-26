using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Nexchar.Documents;
using NexChar.Services;
using NexCharCore;

namespace NexChar.APIControllers
{
    public class CharacterController : ApiController
    {
        
        private readonly CharacterService _fullService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextManager"></param>
        public CharacterController(IContextManager contextManager)
        {
            _fullService = new CharacterService(contextManager);
        }

        /// <summary>
        /// Search for a Character Based on Parameters
        /// </summary>
        /// <returns>CharacterDocument</returns>
        public IEnumerable<CharacterDocument> GetFilteredList()
        {
            return _fullService.GetFiltered((IReadOnlyCollection<KeyValuePair<string, string>>)Request.GetQueryNameValuePairs());
        }

        public IHttpActionResult GetById(int id = 0)
        {

            var unit = _fullService.Get(id);
            if (unit == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(unit);
        }

        [ActionName("createorupdate")]
        public IHttpActionResult PostCreateorUpdate([FromBody] SkillDocument doc)
        {
            var returnDoc = _fullService.CreateOrUpdate(doc);
            if (returnDoc == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(returnDoc);
        }
    }
}
