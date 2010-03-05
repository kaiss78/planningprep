/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: BusinessRulesEvaulatorBase<TEntity>
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
using System.Collections.Generic;
using App.Core.Extensions;

namespace App.Core.BusinessRuleEngine.Rules
{
    ///<summary>
    /// A base class that implementors of <see cref="IBusinessRulesEvaluator{TEntity}"/> can use to provide
    /// business rule evaulation logic for their entites.
    ///</summary>
    ///<typeparam name="TEntity"></typeparam>
    public abstract class BusinessRulesEvaulatorBase<TEntity> : IBusinessRulesEvaluator<TEntity> where TEntity : class
    {
        #region fields
        //The internal dictionary used to store rule sets.
        private readonly Dictionary<string, IBusinessRule<TEntity>> _ruleSets = new Dictionary<string, IBusinessRule<TEntity>>();
        #endregion

        #region methods
        /// <summary>
        /// Adds a <see cref="IBusinessRule{TEntity}"/> instance to the rules evaluator.
        /// </summary>
        /// <param name="rule">The <see cref="IBusinessRule{TEntity}"/> instance to add.</param>
        /// <param name="ruleName">string. The unique name assigned to the business rule.</param>
        protected void AddRule (string ruleName, IBusinessRule<TEntity> rule)
        {
            Check.Require( rule == null, "Cannot add a null rule instance. Expected a non null reference.");
            Check.Require( string.IsNullOrEmpty( ruleName ), "Cannot add a rule with an empty or null rule name.");
            Check.Require( _ruleSets.ContainsKey( ruleName ), "Another rule with the same name already exists. Cannot add duplicate rules.");

            _ruleSets.Add(ruleName, rule);
        }

        /// <summary>
        /// Removes a previously added rule, specified with the <paramref name="ruleName"/>, from the evaluator.
        /// </summary>
        /// <param name="ruleName">string. The name of the rule to remove.</param>
        protected void RemoveRule (string ruleName)
        {
            Check.Require( string.IsNullOrEmpty( ruleName ), "Expected a non empty and non-null rule name." );
            _ruleSets.Remove(ruleName);
        }

        /// <summary>
        /// Evaulates all business rules registred with the evaluator against a entity instance.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> instance against which all 
        /// registered business rules are evauluated.</param>
        public void Evaulate(TEntity entity)
        {
            Check.Require( entity == null, "Cannot evaulate rules against a null reference. Expected a valid non-null entity instance." );
            _ruleSets.Keys.ForEach(x => EvaulateRule(x, entity));
        }

        /// <summary>
        /// Evaulates a business rules against an entity.
        /// </summary>
        /// <param name="ruleName">string. The name of the rule to evaulate.</param>
        /// <param name="entity">A <typeparamref name="TEntity"/> instance against which the business rules are evaulated.</param>
        private void EvaulateRule(string ruleName, TEntity entity)
        {
            Check.Require( entity == null, "Cannot evaulate a business rule set against a null reference." );
            if (_ruleSets.ContainsKey(ruleName))
            {
                _ruleSets[ruleName].Evaluate(entity);
            }
        }
        #endregion
    }
}
