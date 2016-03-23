using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Nexchar.Documents;
using NexChar.Services;
using NexCharCore;

namespace NexChar.APIControllers
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationController : ApiController
    {
        
        private readonly OrganizationService _fullService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextManager"></param>
        public OrganizationController(IContextManager contextManager)
        {
            _fullService = new OrganizationService(contextManager);
        }

        /// <summary>
        /// Search for a Character Based on Parameters
        /// </summary>
        /// <returns>OrganizationDocument</returns>
        public IEnumerable<OrganizationDocument> GetFilteredList()
        {
            return _fullService.GetFiltered((IReadOnlyCollection<KeyValuePair<string, string>>)Request.GetQueryNameValuePairs());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IHttpActionResult GetById(string name = "")
        {

            var unit = _fullService.Get(name);
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
        public IHttpActionResult PostCreateorUpdate([FromBody] OrganizationDocument doc)
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