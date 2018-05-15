using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Contexts;
namespace Domain.Services
{
    public class UnitOfWork : IDisposable
    {
        private CommonDataContext db;
        private bool disposed;
        private Dictionary<string, object> repositories;


        public UnitOfWork(CommonDataContext context)
        {
            db = context;
        }
        public UnitOfWork()
        {
            db = new CommonDataContext();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;

        }

        public BaseRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), db);
                repositories.Add(type, repositoryInstance);
            }
            return (BaseRepository<T>)repositories[type];
        }
    }

}
