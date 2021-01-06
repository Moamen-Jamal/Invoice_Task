using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UnitOfWork
    {
        public EntitiesContext context;
        public Generic<Store> StoTory { get; set; }
        public Generic<Unit> UnitTory { get; set; }
        public Generic<Item> ItemTory { get; set; }
        public Generic<ItemUnit> ItemUnitTory { get; set; }
        public Generic<Invoice> InvoiceTory { get; set; }
        public Generic<InvoiceItemUnit> InvoiceItemUnitTory { get; set; }
        public UnitOfWork(
            EntitiesContext _context,
            Generic<Store> stoTory,
            Generic<Unit> unitTory,
            Generic<Item> itemTory,
            Generic<ItemUnit> itemUnitTory,
            Generic<Invoice> invoiceTory,
            Generic<InvoiceItemUnit> invoiceItemUnitTory
            )
        {
            context = _context;

            StoTory = stoTory;
            StoTory.Context = context;

            UnitTory = unitTory;
            UnitTory.Context = context;

            ItemTory = itemTory;
            ItemTory.Context = context;

            ItemUnitTory = itemUnitTory;
            ItemUnitTory.Context = context;

            InvoiceTory = invoiceTory;
            InvoiceTory.Context = context;

            InvoiceItemUnitTory = invoiceItemUnitTory;
            InvoiceItemUnitTory.Context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
