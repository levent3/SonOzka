using BusinessLayer.Abstract;
using DataAccesLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ManagerBase<T> : IManagerBase<T> where T : class, new()
    {
        public RepositoryBase<T> repository { get ; set ; }
        public ManagerBase()
        {
            repository = new RepositoryBase<T>();
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            return await repository.CreateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public virtual async Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.FindAllAsnyc(filter);
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            var result = repository.FindAllIncludeAsync(filter, include).Result;

            return result;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.FindAsync(filter);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
