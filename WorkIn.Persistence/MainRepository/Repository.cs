using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkIn.Persistence.Data;
using WorkIn.Domain.Entities;

namespace WorkIn.Persistence.MainRepository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities;
        }
        public async Task<T> GetAsync(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefault(predicate);
        }
        public async Task<T> GetLastOrDefault(Expression<Func<T, bool>> predicate)
        {
            return entities.OrderByDescending(e => e.Id).FirstOrDefault(predicate);
        }
        public async Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {

            return entities.Where(predicate);
        }


        public async Task<IQueryable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeExpressions)
        {
            IIncludableQueryable<T, object> query = GetAll().Include(includeExpressions[0]);
            for (int queryIndex = 1; queryIndex < includeExpressions.Length; ++queryIndex)
            {
                query = query.Include(includeExpressions[queryIndex]);
            }
            return query == null ? GetAll() : (IQueryable<T>)query;
        }

        public async Task<T> GetIncludingAsync(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            IIncludableQueryable<T, object> query = entities.Include(includeExpressions[0]);
            for (int queryIndex = 1; queryIndex < includeExpressions.Length; ++queryIndex)
            {
                query = query.Include(includeExpressions[queryIndex]);
            }
            return query == null ? await entities.SingleOrDefaultAsync(s => s.Id == id) : await query.SingleOrDefaultAsync(s => s.Id == id);


        }

        public async Task<T> GetFirstOrDefaultIncluding(Expression<Func<T, bool>> predicate,
          params Expression<Func<T, object>>[] propertySelectors)
        {
            IIncludableQueryable<T, object> query = entities.Include(propertySelectors[0]);
            for (int queryIndex = 1; queryIndex < propertySelectors.Length; ++queryIndex)
            {
                query = query.Include(propertySelectors[queryIndex]);
            }

            return query == null ? entities.FirstOrDefault(predicate) : query.FirstOrDefault(predicate);

        }
        public async Task<T> GetLastOrDefaultIncluding(Expression<Func<T, bool>> predicate,
   params Expression<Func<T, object>>[] propertySelectors)
        {
            IIncludableQueryable<T, object> query = entities.Include(propertySelectors[0]);
            for (int queryIndex = 1; queryIndex < propertySelectors.Length; ++queryIndex)
            {
                query = query.Include(propertySelectors[queryIndex]);
            }

            return query == null ? entities.OrderByDescending(e => e.Id).FirstOrDefault(predicate) : query.OrderByDescending(e => e.Id).FirstOrDefault(predicate);

        }

        public async Task<IQueryable<T>> GetWhereIncluding(Expression<Func<T, bool>> predicate,
          params Expression<Func<T, object>>[] propertySelectors)
        {

            IIncludableQueryable<T, object> query = entities.Include(propertySelectors[0]);
            for (int queryIndex = 1; queryIndex < propertySelectors.Length; ++queryIndex)
            {
                query = query.Include(propertySelectors[queryIndex]);
            }
            return query == null ? entities.Where(predicate) : query.Where(predicate);


        }

        public async Task<int> GetCountWhere(Expression<Func<T, bool>> predicate)
        {
            return entities.Count(predicate);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await context.SaveChangesAsync();
        }


        public async Task InsertAsync(List<T> entityList)
        {
            if (entityList == null || entityList.Count() == 0)
            {
                throw new ArgumentNullException("entity");
            }
            entities.AddRange(entityList);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, string[] proprties)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Attach(entity);
            foreach (var proprty in proprties)
            {
                context.Entry(entity).Property(proprty).IsModified = true;
            }


            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(List<T> entityList, string[] proprties)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException("entity");
            }
            entities.AttachRange(entityList);

            foreach (var entity in entityList)
            {
                foreach (var proprty in proprties)
                {
                    context.Entry(entity).Property(proprty).IsModified = true;
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(List<T> entityList)
        {
            if (entityList == null || entityList.Count() == 0)
            {
                throw new ArgumentNullException("entity");
            }
            entities.RemoveRange(entityList);
            await context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return await entities.AnyAsync(predicate);

        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
