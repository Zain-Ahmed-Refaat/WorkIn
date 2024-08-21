using System.Linq.Expressions;

namespace WorkIn.Persistence.MainRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetLastOrDefault(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeExpressions);
        Task<T> GetIncludingAsync(int id, params Expression<Func<T, object>>[] includeExpressions);
        Task<T> GetFirstOrDefaultIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors);
        Task<T> GetLastOrDefaultIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors);
        Task<IQueryable<T>> GetWhereIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors);
        Task<int> GetCountWhere(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        Task InsertAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, string[] proprties);
        Task UpdateAsync(List<T> entityList, string[] proprties);
        Task DeleteAsync(T entity);
        Task DeleteAsync(List<T> entityList);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
