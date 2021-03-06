﻿using InventoryManager.Models.Backpack;
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
    [Authorize]
    public class BackpackController : Controller
    {
        // GET: Backpack
        public ActionResult Index()
        {
            var service = CreateBackpackService();
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
           
            model.CharacterName = characterService.GetCharacterById(model.CharacterID).CharacterName;
            if (service.CreateBackpack(model))
            {
                TempData["SaveResult"] = "Your Backpack was created.";
                return RedirectToAction("CharacterBackpack", "Character", new { id = model.CharacterID, characterName = model.CharacterName });
            };

            ModelState.AddModelError("", "Backpack could not be created.");

            return View(model);
        }

        public ActionResult Details(int charId, int itemId)
        {
            var svc = CreateBackpackService();
            var model = svc.GetBackpackItemByCharacterId(charId, itemId);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateBackpackService();
            var model = svc.GetBackpackItemById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBackpackService();

            service.DeleteBackpack(id);

            TempData["SaveResult"] = "The item was removed from the bag.";

            return RedirectToAction("Index");
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