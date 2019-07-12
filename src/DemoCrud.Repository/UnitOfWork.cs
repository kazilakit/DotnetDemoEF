using DemoCrud.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCrud.Repository
{
    public class UnitOfWork :IUnitOfWork,IDisposable
    {

        private readonly StudentContext _context;
        private Dictionary<string, object> repositories;
        public UnitOfWork(StudentContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                return;

            _disposed = true;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoriestype = typeof(Repository<>);
                var instance = Activator.CreateInstance(repositoriestype.MakeGenericType(typeof(T)), _context);
                repositories.Add(type,instance);
            }

            return (Repository<T>)repositories[type];
        }

    }
}
