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
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BackpackID,ItemID,CharacterID")]BackpackCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateBackpackService();

            if (service.CreateBackpack(model))
            {
                TempData["SaveResult"] = "Your Character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character could not be created.");

            return View(model);
        }

        private BackpackService CreateBackpackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            return service;
        }
    }
}