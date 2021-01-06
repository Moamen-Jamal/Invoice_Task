using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class EntitiesContext
        : DbContext
    {
        public EntitiesContext(DbContextOptions options): base(options)
        {
        }


        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<ItemUnit> ItemUnits { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<InvoiceItemUnit> InvoiceItemUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemUnitConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemUnitConfiguration());
        }

    }
}
