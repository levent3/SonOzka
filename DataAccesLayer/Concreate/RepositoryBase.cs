using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccesLayer.Concreate
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public SqlDbContext dbContext { get; set; }
        public RepositoryBase()
        {
            dbContext = new SqlDbContext();
        }
        public virtual async Task<int> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).ToListAsync();
            else
                return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            var query = dbContext.Set<T>();
            if (filter != null)
            {
                query.Where(filter);
            }
            var result = include.Aggregate(query.AsQueryable(),
                                    (current, includeprop) => current.Include(includeprop));
            return result;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
            else
                return await dbContext.Set<T>().FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }


    }
}
