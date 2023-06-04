using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //should be modified to list of specs 
            }

            if (spec.orderBy != null)
            {
                query = query.OrderBy(spec.orderBy); //should be modified to list of specs 
            }
            if (spec.orderByDescending != null)
            {
                query = query.OrderByDescending(spec.orderByDescending); //should be modified to list of specs 
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
