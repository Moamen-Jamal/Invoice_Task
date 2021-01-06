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
    public class ItemService
    {
        private Generic<Item> itemTory;
        private UnitOfWork UnitOfWork;

        public ItemService(
            UnitOfWork _UnitOfWork
            )
        {
            UnitOfWork = _UnitOfWork;
            itemTory = UnitOfWork.ItemTory;
        }

        public ItemViewModel GetByID(int id)
        {
            return itemTory.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<ItemViewModel> GetList()
        {
            return itemTory.GetList().ToList().Select(i => i.ToViewModel());
        }
        //public IEnumerable<ItemViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        //{
        //    var query = ItemTory.GetList()
        //        .Include(i => i.Items)
        //        .AsQueryable();
        //    if (id > 0)
        //        query = query.Where(i => i.ID == id);
        //    if (!string.IsNullOrEmpty(name))
        //        query = query.Where(i => i.Name == name);

        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);

        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public ItemEditViewModel Add(ItemEditViewModel editModel)
        {
            EntityEntry<Item> Item = itemTory.Add(editModel.ToModel());
            UnitOfWork.Commit();
            return Item.Entity.ToEditableModel();
        }
        public ItemEditViewModel Update(ItemEditViewModel editModel)
        {
            Item dept = itemTory.Update(editModel.ToModel());
            UnitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            itemTory.Remove(new Item { ID = id });
            UnitOfWork.Commit();
        }
    }
}
