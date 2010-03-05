/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: SpecificationRuleBase<TEntity>
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
using App.Core.BusinessRuleEngine.Specification;

namespace App.Core.BusinessRuleEngine.Rules
{
    /// <summary>
    /// Base implementation that uses <see cref="ISpecification{TEntity}"/> instances that provide the logic to check if the
    /// rule is satisfied.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SpecificationRuleBase<TEntity>
    {
        #region fields
        private ISpecification<TEntity> _rule; //The underlying rule as a specification.
        #endregion

        #region .ctor
        /// <summary>
        /// Default Constructor. 
        /// Protected. Must be called by implementors.
        /// </summary>
        /// <param name="rule">A <see cref="ISpecification{TEntity}"/> instance that specifies the rule.</param>
        protected SpecificationRuleBase(ISpecification<TEntity> rule)
        {
            Check.Require(rule != null, "Expected a non null and valid ISpecification<TEntity> rule instance.");
            _rule = rule;
        }
        #endregion

        #region methods
        /// <summary>
        /// Checks if the entity instance satisfies this rule.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> insance.</param>
        /// <returns>bool. True if the rule is satsified, else false.</returns>
        public bool IsSatisfied(TEntity entity)
        {
            Check.Require( entity != null, "Expected a valid non-null entity instance against which the rule can be evaulated.");
            return _rule.IsSatisfiedBy(entity);
        } 
        #endregion
    }
}
