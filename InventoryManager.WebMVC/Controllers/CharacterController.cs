﻿using InventoryManager.Models;
using InventoryManager.Models.CharacterModels;
using InventoryManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            var service = CreateCharacterService();
            var model = service.GetCharacters();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterService();

            if (service.CreateCharacter(model))
            {
                TempData["SaveResult"] = "Your Character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCharacterService();
            var detail = service.GetCharacterByIdForEdit(id);
            var model =
                new CharacterEdit
                {
                    CharacterID = detail.CharacterID,
                    CharacterName = detail.CharacterName,
                    CharacterClass = detail.CharacterClass,
                    CharacterRace = detail.CharacterRace,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, CharacterEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.CharacterID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCharacterService();

            if (service.UpdateCharacter(model))
            {
                TempData["SaveResult"] = "Your Character was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Character could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCharacterService();

            service.DeleteCharacter(id);

            TempData["SaveResult"] = "Your Character was deleted.";

            return RedirectToAction("Index");
        }

        public ActionResult CharacterBackpack(int id, string characterName)
        {
            var service = CreateBackpackService();
            var model = service.GetCharacterBackpack(id, characterName);
            if (model.BackpackItemList.ToList().Count == 0)
            {
                return RedirectToAction("Create", "Backpack");
            }
            return View(model);
        }

        public ActionResult ItemDetails(int id)
        {
            var service = CreateItemService();
            var model = service.GetItemById(id);
            return ItemDetails(id);
        }

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
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
    }
} 