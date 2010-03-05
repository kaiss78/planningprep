/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: EntityValidatorBase<TEntity>
 * Purpose: 
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

using System.Collections.Generic;
using App.Core.BusinessRuleEngine.Rules;
using App.Core.Extensions;

namespace App.Core.RuleEngine
{
    ///<summary>
    /// Base class that implementors of <see cref="IEntityValidator{TEntity}"/> can use to 
    /// provide validation logic for their entities.
    ///</summary>
    ///<typeparam name="TEntity"></typeparam>
    public abstract class EntityValidatorBase<TEntity> : IEntityValidator<TEntity> where TEntity : class
    {
        #region fields
        //The internal dictionary used to store rule sets.
        private readonly Dictionary<string, IValidationRule<TEntity>> _validations = new Dictionary<string, IValidationRule<TEntity>>();
        private ValidationResult _result = null;
        #endregion

        protected EntityValidatorBase(ValidationResult result)
        {
            _result = result;
        }

        #region methods
        /// <summary>
        /// Adds a <see cref="IValidationRule{TEntity}"/> instance to the entity validator.
        /// </summary>
        /// <param name="rule">The <see cref="IValidationRule{TEntity}"/> instance to add.</param>
        /// <param name="ruleName">string. The unique name assigned to the validation rule.</param>
        protected void AddValidation(string ruleName, IValidationRule<TEntity> rule)
        {
            Check.Require(rule != null, "Cannot add a null rule instance. Expected a non null reference.");
            Check.Require( !string.IsNullOrEmpty( ruleName ), "Cannot add a rule with an empty or null rule name.");
            Check.Require( !_validations.ContainsKey( ruleName ), "Another rule with the same name already exists. Cannot add duplicate rules.");

            _validations.Add(ruleName, rule);
        }

        /// <summary>
        /// Removes a previously added rule, specified with the <paramref name="ruleName"/>, from the evaluator.
        /// </summary>
        /// <param name="ruleName">string. The name of the rule to remove.</param>
        protected void RemoveValidation(string ruleName)
        {
            Check.Require( !string.IsNullOrEmpty( ruleName ), "Expected a non empty and non-null rule name." );
            _validations.Remove(ruleName);
        }

        /// <summary>
        /// Validates an entity against all validations defined for the entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> that contains the results of the validation.</returns>
        public ValidationResult Validate(TEntity entity)
        {   
            if( _result == null )
                _result = new ValidationResult();

            _validations.Keys.ForEach(x =>
                                          {
                                              IValidationRule<TEntity> rule = _validations[x];
                                              if (!rule.Validate(entity))
                                                  _result.AddError(new ValidationError(rule.ValidationMessage,
                                                                                       rule.ValidationProperty));
                                          });
            return _result;
        }
        #endregion
    }

}


