using System;
using System.Collections.Generic;

namespace ComITBakery.Models
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
        public decimal Price {get;set;}
        public int DaysToSell {get;set;}
        public List<Batch> Batches {get;set;}
        public bool IsDeleted {get;set;}
    }
}
