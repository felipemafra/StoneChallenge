using Microsoft.EntityFrameworkCore;
using StoneChallenge.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query;
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
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
