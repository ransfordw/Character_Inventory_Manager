using InventoryManager.Models.Backpack;
using InventoryManager.Services;
using InventoryMangager.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Controllers
{
    public class BackpackController : Controller
    {

        // GET: Backpack
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            var model = service.GetBackpacks();
            return View(model);
        }

        public ActionResult Create()
        {
            var characterService = CreateCharacterService();
            var itemService = CreateItemService();

            ViewBag.CharacterID = new SelectList(characterService.GetCharacters(), "CharacterID", "CharacterName");
            ViewBag.ItemID = new SelectList(itemService.GetItems(), "ItemID", "ItemName");

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BackpackCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBackpackService();
            var characterService = CreateCharacterService();
            var itemService = CreateItemService();

            characterService.GetCharacterById(model.CharacterID);
            itemService.GetItemById(model.ItemID);
            
            ViewBag.CharacterID = new SelectList(characterService.GetCharacters(), "CharacterID", "CharacterName", model.CharacterID);
            ViewBag.ItemID = new SelectList(itemService.GetItems(), "ItemID", "ItemName", model.ItemID);

            if (service.CreateBackpack(model))
            {
                TempData["SaveResult"] = "Your Backpack was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Backpack could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBackpackService();
            var model = svc.GetBackpackItemByCharacterId(id);

            return View(model);
        }

        private BackpackService CreateBackpackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            return service;
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            return service;
        }

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }
    }
}