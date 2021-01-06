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
    public class InvoiceItemUnitService
    {
        private Generic<InvoiceItemUnit> invoiceItemUnitTory;
        private UnitOfWork UnitOfWork;

        public InvoiceItemUnitService(
            UnitOfWork _UnitOfWork
            )
        {
            UnitOfWork = _UnitOfWork;
            invoiceItemUnitTory = UnitOfWork.InvoiceItemUnitTory;
        }

        public InvoiceItemUnitViewModel GetByID(int id)
        {
            return invoiceItemUnitTory.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<InvoiceItemUnitViewModel> GetList()
        {
            return invoiceItemUnitTory?.GetList()?.ToList()?.Select(i => i?.ToViewModel());
        }
        //public IEnumerable<InvoiceItemUnitViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        //{
        //    var query = InvoiceItemUnitTory.GetList()
        //        .Include(i => i.InvoiceItemUnits)
        //        .AsQueryable();
        //    if (id > 0)
        //        query = query.Where(i => i.ID == id);
        //    if (!string.IsNullOrEmpty(name))
        //        query = query.Where(i => i.Name == name);

        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);

        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public InvoiceItemUnitEditViewModel Add(InvoiceItemUnitEditViewModel editModel)
        {
            EntityEntry<InvoiceItemUnit> InvoiceItemUnit = invoiceItemUnitTory.Add(editModel.ToModel());
            UnitOfWork.Commit();
            return InvoiceItemUnit.Entity.ToEditableModel();
        }
        public InvoiceItemUnitEditViewModel Update(InvoiceItemUnitEditViewModel editModel)
        {
            InvoiceItemUnit dept = invoiceItemUnitTory.Update(editModel.ToModel());
            UnitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            invoiceItemUnitTory.Remove(new InvoiceItemUnit { ID = id });
            UnitOfWork.Commit();
        }
    }
}
