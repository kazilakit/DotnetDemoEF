using DemoCrud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCrud.Repository
{
    public interface IRepository<T> : IDisposable 
        where T: BaseEntity
    {
        
        IQueryable<T> GetAll();
        T GetById(object id);
        void Insert(T model);
        void Update(T model);
        void Delete(object id);
        //void Save();
    }
}
