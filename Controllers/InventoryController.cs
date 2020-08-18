using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComITBakery.Models;

using ComITBakery.DAL;

namespace ComITBakery.Controllers
{
    public class InventoryController : Controller
    {
        IStoreInventoryItems _inventoryStorage;

        public InventoryController(IStoreInventoryItems myInventoryStorage)
        {
            _inventoryStorage = myInventoryStorage;
        }

        public IActionResult Index()
        {
            var items = _inventoryStorage.GetAllItems();
            return View(items);
        }

        public IActionResult Details(Guid id) {
            var item = _inventoryStorage.GetById(id);
            return View(item);
        }

        public IActionResult Create() {
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(InventoryItem newItem) {
            newItem.Id = Guid.NewGuid();
            newItem.Batches = new List<Batch>();
            newItem.IsDeleted = false;
            _inventoryStorage.CreateInventoryItem(newItem);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id) {
            var existingItem = _inventoryStorage.GetById(id);
            ViewBag.IsEditing = true;
            return View("Upsert", existingItem);
        }

        [HttpPost]
        public IActionResult Update(InventoryItem itemToUpdate) {
            _inventoryStorage.UpdateInventoryItem(itemToUpdate);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            _inventoryStorage.DeleteInventoryItem(id);
            return RedirectToAction("Index"); 
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
