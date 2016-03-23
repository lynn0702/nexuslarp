using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Nexchar.Documents;
using NexChar.Services;
using NexCharCore;

namespace NexChar.APIControllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerController : ApiController
    {
        
        private readonly PlayerService _fullService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextManager"></param>
        public PlayerController(IContextManager contextManager)
        {
            _fullService = new PlayerService(contextManager);
        }

        /// <summary>
        /// Search for a Character Based on Parameters
        /// </summary>
        /// <returns>CharacterDocument</returns>
        public IEnumerable<PlayerDocument> GetFilteredList()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [ActionName("createorupdate")]
        public IHttpActionResult PostCreateorUpdate([FromBody] PlayerDocument doc)
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