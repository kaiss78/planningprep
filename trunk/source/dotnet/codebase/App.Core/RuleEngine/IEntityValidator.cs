/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: IEntityValidator<TEntity>
 * Purpose: 
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

namespace App.Core.RuleEngine
{
    /// <summary>
    /// Interface implemented by different flavors of validators that provide validation
    /// logic on domain entities.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityValidator<TEntity>
    {
        /// <summary>
        /// Validates an entity against all validations defined for the entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> that contains the results of the validation.</returns>
        ValidationResult Validate(TEntity entity);
    }
}


