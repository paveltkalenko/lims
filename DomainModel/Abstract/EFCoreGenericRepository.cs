using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DomainModel.Interfaces;
namespace DomainModel.Abstract
{
    class EFCoreGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //    private static IEnumerable<Users> fakeUsers
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public void Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
