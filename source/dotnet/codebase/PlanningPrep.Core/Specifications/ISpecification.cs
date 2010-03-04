/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: ISpecification<T>
 * Purpose: 
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
using System;
using System.Linq.Expressions;

namespace PlanningPrep.Core.BusinessRuleEngine.Specification
{
    /// <summary>
    /// The <see cref="ISpecification{TEntity}"/> interface defines a basic contract to express specifications declaratively.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the expression that encapsulates the criteria of the specification.
        /// </summary>
        Expression<Func<T, bool>> Predicate { get; }

        /// <summary>
        /// Evaluates the specification against an entity of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="T"/> instance to evaluate the specificaton
        /// against.</param>
        /// <returns>Should return true if the specification was satisfied by the entity, else false. </returns>
        bool IsSatisfiedBy(T entity);
    }
}