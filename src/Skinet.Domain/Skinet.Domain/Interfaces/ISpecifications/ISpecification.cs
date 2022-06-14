using System.Linq.Expressions;

namespace Skinet.Domain.Interfaces.ISpecifications;

public interface ISpecification<T>
{
    // If you want to include foreign keyed table data, you could add it using this method.
    List<Expression<Func<T, object>>> Includes { get; }
}