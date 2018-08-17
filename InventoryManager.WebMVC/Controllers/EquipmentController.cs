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
        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }
    }
}