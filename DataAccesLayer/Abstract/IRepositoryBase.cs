using DataAccesLayer.Context;
using System.Linq.Expressions;

namespace DataAccesLayer.Abstract
{
    public interface IRepositoryBase<T> where T : class, new()
    {

        SqlDbContext dbContext { get; set; }

        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> filter = null);
        Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null);

        Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] include);

    }
}
