using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Shared.BaseClasses;

namespace Skinet.Domain.Entities;
#nullable disable

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specs)
    {
        IQueryable<TEntity> query = inputQuery;
        if (specs.Criteria is not null)
        {
            query = query.Where(specs.Criteria);
        }

        query = specs.Includes.Aggregate(query
                                      , (current
                                       , include) => current.Include(include));

        return query;
    }
}