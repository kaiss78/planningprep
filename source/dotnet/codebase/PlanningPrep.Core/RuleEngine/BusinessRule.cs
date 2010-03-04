﻿/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: BusinessRule<TEntity>
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
using PlanningPrep.Core.BusinessRuleEngine.Specification;

namespace PlanningPrep.Core.BusinessRuleEngine.Rules
{
    /// <summary>
    /// Implements the <see cref="IBusinessRule{TEntity}"/> interface and inherits from the
    /// <see cref="SpecificationRuleBase{TEntity}"/> to provide a implementation of a business rule that
    /// uses specifications as rule logic.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BusinessRule<TEntity> : SpecificationRuleBase<TEntity>, IBusinessRule<TEntity> where TEntity : class
    {
        #region fields
        private Action<TEntity> _action; //The business action to undertake.
        #endregion

        #region ctor
        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="BusinessRule{TEntity}"/> instance.
        /// </summary>
        /// <param name="rule">A <see cref="ISpecification{TEntity}"/> instance that acts as the underlying
        /// specification that this business rule is evaulated against.</param>
        /// <param name="action">A <see cref="Action{TEntity}"/> instance that is invoked when the business rule
        /// is satisfied.</param>
        public BusinessRule(ISpecification<TEntity> rule, Action<TEntity> action) : base(rule)
        {
            Check.Require(action == null, "Please provide a valid non null Action<TEntity> delegate instance.");
            _action = action;
        } 
        #endregion

        #region methods
        /// <summary>
        /// Evaulates the business rule against an entity instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/>. The entity instance against which
        /// the business rule is evaulated.</param>
        public void Evaluate(TEntity entity)
        {
            Check.Require(entity == null, "Cannot evaulate a business rule against a null reference.");

            if (IsSatisfied(entity))
                _action(entity);
        } 
        #endregion
    }
}
