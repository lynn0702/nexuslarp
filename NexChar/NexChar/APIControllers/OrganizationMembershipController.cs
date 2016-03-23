using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OrganizationMembershipController : ApiController
    {
        
        private readonly CharacterService _fullService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextManager"></param>
        public OrganizationMembershipController(IContextManager contextManager)
        {
            _fullService = new CharacterService(contextManager);
        }

        /// <summary>
        /// Search for a Character Based on Parameters
        /// </summary>
        /// <returns>CharacterDocument</returns>
        [ActionName("getbycharacter")]
        public IEnumerable<OrganizationMembershipDocument> GetByCharacter(int id)
        {
            return _fullService.GetOrganizationMembershipsByCharacter((id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <param name="docs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [ActionName("createorupdate")]
        public IHttpActionResult PostCreateorUpdate([FromBody] List<OrganizationMembershipDocument> docs)
        {
            var returnDoc = _fullService.CreateOrUpdateOrganizationMemberships(docs);
            if (returnDoc == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(returnDoc);
        }
    }
}
