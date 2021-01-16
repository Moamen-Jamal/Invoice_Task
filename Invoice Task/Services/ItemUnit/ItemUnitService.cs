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
    public class ItemUnitService
    {
        private Generic<ItemUnit> itemUnitTory;
        private UnitOfWork UnitOfWork;

        public ItemUnitService(
            UnitOfWork _UnitOfWork
            )
        {
            UnitOfWork = _UnitOfWork;
            itemUnitTory = UnitOfWork.ItemUnitTory;
        }

        public ItemUnitViewModel GetByID(int id)
        {
            return itemUnitTory.GetByID(id).ToViewModel();
        }
        public IEnumerable<ItemUnitViewModel> GetList()
        {
            return itemUnitTory.GetList().ToList().Select(i => i.ToViewModel());
        }
        //public IEnumerable<ItemUnitViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        //{
        //    var query = ItemUnitTory.GetList()
        //        .Include(i => i.ItemUnits)
        //        .AsQueryable();
        //    if (id > 0)
        //        query = query.Where(i => i.ID == id);
        //    if (!string.IsNullOrEmpty(name))
        //        query = query.Where(i => i.Name == name);

        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);

        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public ItemUnitEditViewModel Add(ItemUnitEditViewModel editModel)
        {
            EntityEntry<ItemUnit> ItemUnit = itemUnitTory.Add(editModel.ToModel());
            UnitOfWork.Commit();
            return ItemUnit.Entity.ToEditableModel();
        }
        public ItemUnitEditViewModel Update(ItemUnitEditViewModel editModel)
        {
            ItemUnit dept = itemUnitTory.Update(editModel.ToModel());
            UnitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            itemUnitTory.Remove(new ItemUnit { ID = id });
            UnitOfWork.Commit();
        }
    }
}
