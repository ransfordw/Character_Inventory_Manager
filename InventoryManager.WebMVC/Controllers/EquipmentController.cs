using InventoryManager.Models.Equipment;
using InventoryManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            var model = service.GetEquipments();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateEquipmentService();

            if (service.CreateEquipment(model))
            {
                TempData["SaveResult"] = "Your Equipment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Equipment could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateEquipmentService();
            var detail = service.GetEquipmentById(id);
            var model =
                new EquipmentEdit
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
        public ActionResult Edit (int id, EquipmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ItemID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEquipmentService();

            if (service.UpdateEquipment(model))
            {
                TempData["SaveResult"] = "Your equipment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your equipment could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEquipmentService();

            service.DeleteEquipment(id);

            TempData["SaveResult"] = "Your equipment was deleted.";

            return RedirectToAction("Index");
        }


        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }
    }
}