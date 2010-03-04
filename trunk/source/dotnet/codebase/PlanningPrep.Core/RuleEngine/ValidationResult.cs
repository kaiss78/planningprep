﻿/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: ValidationResult
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
using PlanningPrep.Core.BusinessRuleEngine.Rules;

namespace PlanningPrep.Core.RuleEngine
{
    /// <summary>
    /// Contains the result of a <see cref="IEntityValidator{TEntity}.Validate"/> method call.
    /// </summary>
    public class ValidationResult
    {
        #region fields
        private readonly List<ValidationError> _errors = new List<ValidationError>();
        #endregion

        #region properties
        /// <summary>
        /// Gets wheater the validation operation on an entity was valid or not.
        /// </summary>
        public bool IsValid { get { return _errors.Count == 0; } }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ValidationError}"/> that can be used to enumerate over
        /// the validation errors as a result of a <see cref="IEntityValidator{TEntity}.Validate"/> method
        /// call.
        /// </summary>
        public IEnumerable<ValidationError> Errors
        {
            get
            {
                foreach (var error in _errors)
                    yield return error;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Adds a validation error into the result.
        /// </summary>
        /// <param name="error"></param>
        public void AddError(ValidationError error)
        {
            _errors.Add(error);    
        }

        /// <summary>
        /// Removes a validation error from the result.
        /// </summary>
        /// <param name="error"></param>
        public void RemoveError(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }
        #endregion
    }
}


