using DemoCrud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCrud.Repository
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        void SaveChanges();

    }
}
