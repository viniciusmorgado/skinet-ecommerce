using System.Linq.Expressions;
using Skinet.Domain.Interfaces.ISpecifications;
namespace Skinet.Domain.BaseSpecification;

#nullable disable

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification( Expression<Func<T
                            , bool>> criteria )
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }
    
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}