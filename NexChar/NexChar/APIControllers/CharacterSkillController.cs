using System;
using System.Collections.Generic;
using System.Web.Http;
using Nexchar.Documents;
using NexChar.Services;
using NexCharCore;

namespace NexChar.APIControllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CharacterSkillController : ApiController
    {
        
        private readonly CharacterService _fullService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextManager"></param>
        public CharacterSkillController(IContextManager contextManager)
        {
            _fullService = new CharacterService(contextManager);
        }

        /// <summary>
        /// Search for a Character Based on Parameters
        /// </summary>
        /// <returns>CharacterDocument</returns>
        [ActionName("getbycharacter")]
        public IEnumerable<CharacterSkillDocument> GetByCharacter(int id)
        {
            return _fullService.GetSkillsByCharacter((id));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [ActionName("createorupdate")]
        public IHttpActionResult PostCreateorUpdate([FromBody] List<CharacterSkillDocument> docs)
        {
            var returnDoc = _fullService.CreateOrUpdateSkills(docs);
            if (returnDoc == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(returnDoc);
        }
    }
}
