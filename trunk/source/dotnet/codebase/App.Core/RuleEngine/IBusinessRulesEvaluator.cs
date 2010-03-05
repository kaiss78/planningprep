/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: IBusinessRulesEvaluator<TEntity>
 * Purpose: 
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
namespace App.Core.BusinessRuleEngine.Rules
{
    /// <summary>
    /// Defines an interface implemented by a business rule evaulator for an entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type that the business rules are applicable for.</typeparam>
    public interface IBusinessRulesEvaluator<TEntity>
    {
        /// <summary>
        /// Evaulates a business rules against an entity.
        /// </summary>
        /// <param name="entity">A <typeparamref name="TEntity"/> instance against which the business
        /// rules are evaulated.</param>
        void Evaulate(TEntity entity);
    }
}
