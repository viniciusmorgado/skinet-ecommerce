﻿using System.Linq.Expressions;

namespace Skinet.Domain.Interfaces.ISpecifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}