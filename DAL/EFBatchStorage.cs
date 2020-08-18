using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using ComITBakery.Models;


namespace ComITBakery.DAL
{
    public class EFBatchStorage : IStoreBatches
    {
        readonly BakeryContext _context;
        IStoreInventoryItems _inventoryStorage;

        public EFBatchStorage(BakeryContext myContext, IStoreInventoryItems myInventoryStorage) {
            _context = myContext;
            _inventoryStorage = myInventoryStorage;
        }

        public void CreateBatch(Batch batchToCreate) {
            var item = _inventoryStorage.GetById(batchToCreate.InventoryItemId);
            item.Batches.Add(batchToCreate);
            _context.SaveChanges();
        }

        public void UpdateBatch(Batch batchToUpdate) {

        }

        public void DeleteBatch(Guid id) {

        }
    }
}