using DataAccesLayer.Concreate;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IManagerBase<T> where T : class, new()
    {
        public RepositoryBase<T> repository { get; set; }

        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>>? filter = null);
        Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>>? filter = null);

        Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>>? filter = null
            , params Expression<Func<T, object>>[]? include);


    }
}
