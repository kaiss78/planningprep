/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: IBusinessRule <TEntity>
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
    /// An interface that defines business rule for an entity instance.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that this business rule evaluates.</typeparam>
    public interface IBusinessRule <TEntity>
    {
        /// <summary>
        /// Evaulates the business rule against an entity instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/>. The entity instance against which
        /// the business rule is evaulated.</param>
        void Evaluate(TEntity entity);
    }
}
