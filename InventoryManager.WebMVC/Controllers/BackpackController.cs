using InventoryManager.Models.Backpack;
using InventoryManager.Services;
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
        public ActionResult Create(BackpackCreate item)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            
            if (service.CreateBackpack(item))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}