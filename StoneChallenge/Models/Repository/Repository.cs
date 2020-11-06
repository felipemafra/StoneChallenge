using Microsoft.EntityFrameworkCore;
using StoneChallenge.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoneChallenge.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal StoneChallengeContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(StoneChallengeContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> oderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = GetById(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
