using DemoCrud.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCrud.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable 
        where T : BaseEntity
    {
        #region Properties

        private StudentContext _context;
        private DbSet<T> table;
        public IUnitOfWork _unitOfWork;

        #endregion
        #region ctor
        public Repository(StudentContext context)
        {
            this._context = context;
            table = _context.Set<T>();
            _unitOfWork = new UnitOfWork(context);
        }
        #endregion


        #region methods
        public void Delete(object id)
        {
            T existing = GetById(id);
            table.Remove(existing);
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                table.Attach(entity);
            }
            table.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            entity.CreateDate = DateTime.Now;
            table.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion


        #region disposal
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
