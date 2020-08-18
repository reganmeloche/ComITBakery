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
    public class BatchController : Controller
    {
        IStoreBatches _batchStorage;

        public BatchController(IStoreBatches myBatchStorage)
        {
            _batchStorage = myBatchStorage;
        }


        public IActionResult Create(Guid id) {
            var newBatch = new Batch();
            newBatch.InventoryItemId = id;
            return View(newBatch);
        }

        [HttpPost]
        public IActionResult Create(Batch newBatch) {
            newBatch.RemainingQuantity = newBatch.InitialQuantity;
            newBatch.IsDeleted = false;
            _batchStorage.CreateBatch(newBatch);
            return View("Index", "Inventory");
        }


        // public IActionResult Update(Guid id) {
        //     var existingItem = _inventoryStorage.GetById(id);
        //     ViewBag.IsEditing = true;
        //     return View("Upsert", existingItem);
        // }

        // [HttpPost]
        // public IActionResult Update(InventoryItem itemToUpdate) {
        //     _inventoryStorage.UpdateInventoryItem(itemToUpdate);
        //     return RedirectToAction("Index"); 
        // }

        // [HttpPost]
        // public IActionResult Delete(Guid id) {
        //     _inventoryStorage.DeleteInventoryItem(id);
        //     return RedirectToAction("Index"); 
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
