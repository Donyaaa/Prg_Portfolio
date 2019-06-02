using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prg_Portfolio.Models.DomainModel;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Prg_Portfolio.Models.Repository
{
    public class Rep<TEntity> where TEntity : class
    {
        private DB_PortfolioEntities _Context;
        private DbSet<TEntity> _dbset;
       
        public Rep(DB_PortfolioEntities Context)
        {
            _Context = Context;
            _dbset = Context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }
        public virtual TEntity GetById(object id)
        {

            return _dbset.Find(id);

        }
        public virtual void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            if (_Context.Entry(entity).State == EntityState.Detached)

            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }
        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }
        public virtual void Save()
        {
            _Context.SaveChanges();
        }
    }
}