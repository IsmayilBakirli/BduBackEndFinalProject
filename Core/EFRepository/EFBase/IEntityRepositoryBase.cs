using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EFRepository.EFBase
{
    public interface IEntityRepositoryBase<TEntity>
        where TEntity : class,IEntity,new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>>? expression,int skip=0,int take = int.MaxValue, params string[] includes);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression, int skip = 0, params string[] includes);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
