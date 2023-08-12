using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CommonCoreLayer.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity:class, IEntity,new()
    {
        List<TEntity> GetAllEntity(Expression<Func<TEntity, bool>> expression = null);
        TEntity GetEntity(Expression<Func<TEntity, bool>> expression);
        void AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}
