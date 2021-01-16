using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace Services
{
    public class InvoiceService
    {
        private Generic<Invoice> invoiceTory;
        private Generic<InvoiceItemUnit> invoiceItemUnitTory;
        private UnitOfWork UnitOfWork;

        public InvoiceService(
            UnitOfWork _UnitOfWork
            )
        {
            UnitOfWork = _UnitOfWork;
            invoiceTory = UnitOfWork.InvoiceTory;
            invoiceItemUnitTory = UnitOfWork.InvoiceItemUnitTory;
        }

        public InvoiceViewModel GetByID(int id)
        {
            return invoiceTory.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<InvoiceViewModel> GetList()
        {
            return invoiceTory?.GetList()?.ToList()?.Select(i => i?.ToViewModel());
        }
        //public IEnumerable<InvoiceViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        //{
        //    var query = InvoiceTory.GetList()
        //        .Include(i => i.Invoices)
        //        .AsQueryable();
        //    if (id > 0)
        //        query = query.Where(i => i.ID == id);
        //    if (!string.IsNullOrEmpty(name))
        //        query = query.Where(i => i.Name == name);

        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);

        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public InvoiceEditViewModel Add(InvoiceEditViewModel editModel)
        {
            EntityEntry<Invoice> Invoice = invoiceTory.Add(editModel.ToModel());
            
            UnitOfWork.Commit();
            return Invoice.Entity.ToEditableModel();
        }
        public InvoiceEditViewModel Update(InvoiceEditViewModel editModel)
        {
            Invoice dept = invoiceTory.Update(editModel.ToModel());
            foreach (var u in editModel.InvoiceItemUnit)
            {
                invoiceItemUnitTory.Update(u.ToModel());

            }
            UnitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            InvoiceItemUnit invoiceitemUnit = invoiceItemUnitTory.GetList().Where(i => i.InvoiceID == id).FirstOrDefault();
            invoiceItemUnitTory.Remove(new InvoiceItemUnit { ID = invoiceitemUnit.ID });
            invoiceTory.Remove(new Invoice { ID = id });
            UnitOfWork.Commit();
        }
    }
}
