using System.ComponentModel;
using System.Linq.Expressions;

namespace Application.Common.Sieve
{
    public class SieveProcessor
    {
        public PagedList<TEntity> Apply<TEntity>(SieveModel sieveModel, IQueryable<TEntity> entity,
            bool applySearching = true, bool applyFiltering = true, bool applySorting = true)
        {
            var result = entity;

            if (applySearching)
            {
                result = ApplySearching(sieveModel, result);
            }

            if (applyFiltering)
            {
                result = ApplyFiltering(sieveModel, result);
            }

            if (applySorting)
            {
                result = ApplySorting(sieveModel, result);
            }

            return GetPagedList(sieveModel, result);
        }

        private IQueryable<TEntity> ApplySearching<TEntity>(SieveModel sieveModel,
            IQueryable<TEntity> entity)
        {
            if (string.IsNullOrWhiteSpace(sieveModel.Searching))
            {
                return entity;
            }

            IQueryable<TEntity> result = null;

            var parameter = Expression.Parameter(typeof(TEntity), "entity");

            var filterSearchValue = Expression.Constant(sieveModel.Searching);

            var entityProperties = typeof(TEntity).GetProperties();

            foreach (var property in entityProperties)
            {                
                var entityProperty = Expression.Property(parameter, property);
                                
                var containsMethodInfo = typeof(string).GetMethods().First(m => 
                    m.Name == "Contains" && m.GetParameters().Length == 1);

                MethodCallExpression containsMethod;

                if (property.PropertyType.Name == nameof(String))
                {
                    containsMethod = Expression.Call(entityProperty, containsMethodInfo, filterSearchValue);
                }
                else
                {
                    var toStringMethod = Expression.Call(entityProperty, nameof(object.ToString), null);
                    containsMethod = Expression.Call(toStringMethod, containsMethodInfo, filterSearchValue);
                }

                var matches = entity.Where(Expression.Lambda<Func<TEntity, bool>>(containsMethod, parameter));
                                
                if (matches.Count() > 0)
                {
                    if (entity.Any()) result = matches;
                    else result.Concat(matches);
                }
            }

            return result;
        }

        private IQueryable<TEntity> ApplyFiltering<TEntity>(SieveModel sieveModel,
            IQueryable<TEntity> entity)
        {
            var result = entity;

            if (sieveModel.Filters is null)
            {
                return result;
            }

            var parameter = Expression.Parameter(typeof(TEntity), "entity");

            var entityProperties = typeof(TEntity).GetProperties();

            foreach (var filter in sieveModel.GetFiltersParsed())
            {
                var entityPropertyInfo = entityProperties.FirstOrDefault(property =>
                    property.Name.ToLower() == filter.ProperyName.ToLower());

                var propertyValue = Expression.Property(parameter, entityPropertyInfo);

                var converter = TypeDescriptor.GetConverter(entityPropertyInfo);

                dynamic? convertedFilterValue = converter.CanConvertFrom(typeof(string))
                    ? converter.ConvertFrom(filter.Value)
                    : Convert.ChangeType(filter.Value, entityPropertyInfo.PropertyType);

                var filterValue = Expression.Constant(convertedFilterValue);

                var comparisonOperation = (BinaryExpression)GetComparisonOperation(filter,
                    propertyValue, filterValue);

                result = result.Where(Expression.Lambda<Func<TEntity, bool>>(comparisonOperation, parameter));
            }

            return result;
        }

        private BinaryExpression GetComparisonOperation(FilterTerm filterTerm, dynamic propertyValue,
            dynamic filterValue)
        {
            switch (filterTerm.OperatorParsed)
            {
                case FilterOperator.Equals:
                    return Expression.Equal(propertyValue, filterValue);
                case FilterOperator.NotEquals:
                    return Expression.NotEqual(propertyValue, filterValue);
                case FilterOperator.LessThan:
                    return Expression.LessThan(propertyValue, filterValue);
                case FilterOperator.GreaterThan:
                    return Expression.GreaterThan(propertyValue, filterValue);
                default:
                    return Expression.Equal(propertyValue, filterValue);

            }
        }

        private IQueryable<TEntity> ApplySorting<TEntity>(SieveModel sieveModel, IQueryable<TEntity> entity)
        {
            var result = entity;

            if (sieveModel.SortProperty is null)
            {
                return result;
            }

            var parameter = Expression.Parameter(typeof(TEntity), "entity");

            var entityProperties = typeof(TEntity).GetProperties();

            var entityPropertyInfo = entityProperties.FirstOrDefault(property =>
                    property.Name.ToLower() == sieveModel.SortProperty.ToLower());

            var entityProperty = Expression.Property(parameter, entityPropertyInfo);

            var lambda = Expression.Lambda(entityProperty, parameter);

            var OrderByMethod = typeof(Queryable).GetMethods().Single(method =>
                method.Name == "OrderBy" && method.GetParameters().Length == 2);

            var genericMethod = OrderByMethod.MakeGenericMethod(typeof(TEntity), entityProperty.Type);

            result = (IQueryable<TEntity>)genericMethod.Invoke(null, new object[] { entity, lambda });

            return result;
        }

        private PagedList<TEntity> GetPagedList<TEntity>(SieveModel sieveModel, IQueryable<TEntity> entity)
        {
            var count = entity.Count();

            var currentPage = sieveModel?.Page ?? 1;
            var pageSize = sieveModel?.PageSize ?? count;
                        
            entity = entity.Skip((currentPage - 1) * pageSize).Take(pageSize);

            var pagedList = new PagedList<TEntity>(entity, currentPage, pageSize, count);

            return pagedList;
        }
    }
}
