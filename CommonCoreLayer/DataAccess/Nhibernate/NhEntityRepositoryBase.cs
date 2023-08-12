using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CommonCoreLayer.DataAccess.Nhibernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
    {
        private NhibernateHelper nhibernateHelper;
        public NhEntityRepositoryBase(NhibernateHelper nhibernateHelper)
        {
            this.nhibernateHelper = nhibernateHelper;
        }
        public void AddEntity(TEntity entity)
        {
            using (var session=nhibernateHelper.OpenSession())
            {
                session.Save(entity);
            }
        }

        public void DeleteEntity(TEntity entity)
        {
            using (var session=nhibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public List<TEntity> GetAllEntity(Expression<Func<TEntity, bool>> expression = null)
        {
            using (var session = nhibernateHelper.OpenSession())
            {
                return expression != null ? session.Query<TEntity>().Where(expression).ToList() : session.Query<TEntity>().ToList();
            }
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> expression)
        {
            using (var session = nhibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().FirstOrDefault(expression);
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            using (var session=nhibernateHelper.OpenSession())
            {
                session.Update(entity);
            }
        }
    }
}
