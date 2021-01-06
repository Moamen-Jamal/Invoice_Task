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
    public class UnitService
    {
        private Generic<Unit> unitTory;
        private UnitOfWork unitOfWork;

        public UnitService(
            UnitOfWork _unitOfWork
            )
        {
            unitOfWork = _unitOfWork;
            unitTory = unitOfWork.UnitTory;
        }

        public UnitViewModel GetByID(int id)
        {
            return unitTory.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<UnitViewModel> GetList()
        {
            return unitTory?.GetList()?.ToList()?.Select(i => i?.ToViewModel());
        }
        //public IEnumerable<UnitViewModel> Get(int id = 0, string name = "", int pageIndex = 0, int pageSize = 20)
        //{
        //    var query = unitTory.GetList()
        //        .Include(i => i.Items)
        //        .AsQueryable();
        //    if (id > 0)
        //        query = query.Where(i => i.ID == id);
        //    if (!string.IsNullOrEmpty(name))
        //        query = query.Where(i => i.Name == name);

        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);

        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public UnitEditViewModel Add(UnitEditViewModel editModel)
        {
            EntityEntry<Unit> Unit = unitTory.Add(editModel.ToModel());
            unitOfWork.Commit();
            return Unit.Entity.ToEditableModel();
        }
        public UnitEditViewModel Update(UnitEditViewModel editModel)
        {
            Unit dept = unitTory.Update(editModel.ToModel());
            unitOfWork.Commit();
            return editModel;
        }
        public void Remove(int id)
        {
            unitTory.Remove(new Unit { ID = id });
            unitOfWork.Commit();
        }
    }
}
