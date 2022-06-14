﻿using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Shared.BaseClasses;

namespace Skinet.Domain.Specifications;
#nullable disable

public class SpecifierEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery( IQueryable<TEntity> inputQuery
                                              , ISpecification<TEntity> specs )
    {
        try
        {
            IQueryable<TEntity> query = inputQuery;
            
            if (specs is null || query is null)
                throw new NullReferenceException("Specs or query of the evaluator are null.");
        
            query = specs.Includes.Aggregate(query, (current, include) => 
                    current.Include(include));
            return query;
        }
        catch (Exception ex)
        {
            throw new Exception("Specs evaluator has failed!", ex);
        }
    }
}