using System;
using System.Collections.Generic;

using ComITBakery.Models;


namespace ComITBakery.DAL
{
    public interface IStoreInventoryItems
    {
        List<InventoryItem> GetAllItems();

        InventoryItem GetById(Guid id);

        void CreateInventoryItem(InventoryItem itemToCreate);

        void UpdateInventoryItem(InventoryItem itemToUpdate);

        void DeleteInventoryItem(Guid id);

    }
}