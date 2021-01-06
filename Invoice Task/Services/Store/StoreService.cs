using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace Services
{
    public class StoreService
    {
        Generic<Store> stoTory;
        UnitOfWork unitOfWork;

        public StoreService(
            UnitOfWork _unitOfWork
            )
        {
            unitOfWork = _unitOfWork;
            stoTory = unitOfWork.StoTory;
        }

        public StoreViewModel GetByID(int id)
        {
            return stoTory.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<StoreViewModel> GetList()
        {
            return stoTory.GetList().ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<StoreViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        {
            var query = stoTory.GetList()
                .Include(i => i.Items)
                .AsQueryable();
            if (id > 0)
                query = query.Where(i => i.ID == id);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name == name);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());
        }
        public StoreEditViewModel Add(StoreEditViewModel editModel)
        {
            EntityEntry<Store> store = stoTory.Add(editModel.ToModel());
            unitOfWork.Commit();
            return store.Entity.ToEditableModel();
        }
        public StoreEditViewModel Update(StoreEditViewModel editModel)
        {
            Store dept = stoTory.Update(editModel.ToModel());
            unitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            stoTory.Remove(new Store { ID = id });
            unitOfWork.Commit();
        }
    }
}
