using InventoryManager.Models.ItemModels;
using InventoryManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            var model = service.GetItems();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateItemService();

            if (service.CreateItem(model))
            {
                TempData["SaveResult"] = "Your Item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateItemService();
            var detail = service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemID = detail.ItemID,
                    ItemName = detail.ItemName,
                    ItemType = detail.ItemType,
                    ItemDescription = detail.ItemDescription,
                    ItemValue = detail.ItemValue,
                    Currency = detail.Currency,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ItemID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateItemService();

            if (service.UpdateItem(model))
            {
                TempData["SaveResult"] = "Your Item was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Item could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Your Item was deleted.";

            return RedirectToAction("Index");
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            return service;
        }
    }
}