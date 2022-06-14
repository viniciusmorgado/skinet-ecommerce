using System.Linq.Expressions;
using Skinet.Domain.Interfaces.ISpecifications;

namespace Skinet.Domain.Specifications;
#nullable disable

public class BaseSpecification<T> : ISpecification<T>
{
    public List<Expression<Func<T, object>>> Includes { get; } = new();

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}