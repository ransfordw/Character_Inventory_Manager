using InventoryManager.Models.CharacterModels;
using InventoryManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManager.WebApi.Controllers
{
    [Authorize]
    public class CharacterController : ApiController
    {
        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCharacterService();
            service.CreateCharacter(character);

            return Ok();
        }

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }

    }


}
