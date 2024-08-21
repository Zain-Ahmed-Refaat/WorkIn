using System.Linq.Expressions;
using System.Reflection;
using WorkIn.Domain.Common;

namespace WorkIn.Domain.Extensions
{
    public static class DataPagerExtension
    {
        public static PagedModel<TModel> Paginate<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

            page = (page <= 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.Count();

            if (limit <= 0 && totalItemsCountTask == 0) limit = 1;
            else if (limit <= 0) limit = totalItemsCountTask;

            var startRow = (page - 1) * limit;
            paged.Items = query
                       .Skip(startRow)
                       .Take(limit)
                       .ToList();

            paged.TotalItems = totalItemsCountTask;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }


        public static PagedModel<TModel> Paginate<TModel>(
          this List<TModel> query,
          int page,
          int limit)
          where TModel : class
        {

            var paged = new PagedModel<TModel>();

            page = (page <= 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.Count();

            if (limit <= 0 && totalItemsCountTask == 0) limit = 1;
            else if (limit <= 0) limit = totalItemsCountTask;

            var startRow = (page - 1) * limit;
            paged.Items = query
                       .Skip(startRow)
                       .Take(limit)
                       .ToList();

            paged.TotalItems = totalItemsCountTask;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }

        public static List<T> Filter<T>(this IQueryable<T> source, string ColumnName, string SearchText)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            MemberExpression member = Expression.Property(param, ColumnName);
            ConstantExpression constant = Expression.Constant(SearchText);
            MethodInfo containsMethod = typeof(string).GetMethod("Equals");
            Expression exp = Expression.Call(member, containsMethod, constant);
            var deleg = Expression.Lambda<Func<T, bool>>(exp, param).Compile();
            return source.Where(deleg).ToList();

        }
    }
}
