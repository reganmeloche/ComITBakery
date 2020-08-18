using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ComITBakery.Models;

namespace ComITBakery.DAL
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options) {}
        public DbSet<InventoryItem> Items {get;set;}
    }
}