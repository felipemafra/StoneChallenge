using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoneChallenge.Models.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> oderBy = null,
            string includeProperties = null
            );

        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null
            );

        void Insert(TEntity entity);

        void Delete(int id);

        void Delete(TEntity entity);

    }
}
