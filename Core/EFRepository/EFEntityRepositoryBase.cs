using Core.EFRepository.EFBase;
using Entity.Base;
using Exceptions.EntityExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EFRepository
{
    public class EFEntityRepositoryBase<TEntity, IContext> : IEntityRepositoryBase<TEntity>
                where TEntity : class, IEntity, new()
                where IContext:DbContext
    {
        private readonly IContext _context;
        public EFEntityRepositoryBase(IContext context)
        {
            _context = context;
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression, int skip = 0, int take = int.MaxValue, params string[] includes)
        {
            var query = expression == null ?
                _context.Set<TEntity>().AsNoTracking() :
                _context.Set<TEntity>().Where(expression).AsNoTracking() ;

            if (skip != 0)
            {
                query = query.Skip(skip) ;
            }

            query = query.Take((int)take);

            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            var data =await query.ToListAsync();
            if(data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression, int skip = 0, params string[] includes)
        {
            var query = expression == null ?
                _context.Set<TEntity>().AsNoTracking() :
                _context.Set<TEntity>().Where(expression).AsNoTracking();
            if(skip != 0)
            {
                query = query.Skip(skip);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            var data = await query.FirstOrDefaultAsync();
            if(data is null)
            {
                throw new EntityCouldNotFoundException();
            }
            return data;


        }
        public async Task Create(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Added;
            await _context.SaveChangesAsync();

        }
        public async Task Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
      
    }
}