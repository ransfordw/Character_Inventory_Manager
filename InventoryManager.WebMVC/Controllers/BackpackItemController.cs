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
    public class BackpackItemController : Controller
    {
        // GET: BackpackItem
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            var model = service.GetBackpackItems();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BackpackItemCreate item)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BackpackService(userId);
            
            if (service.CreateBackpackItem(item))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}