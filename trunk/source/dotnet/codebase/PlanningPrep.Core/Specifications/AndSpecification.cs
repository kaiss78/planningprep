/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: AndSpecification<T>
 * Purpose: 
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
namespace PlanningPrep.Core.BusinessRuleEngine.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftHandSide;
        private readonly ISpecification<T> _rightHandSide;

        /// <summary>
        /// Initializes a new instance of the <see cref="AndSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="leftHandSide">The left hand side.</param>
        /// <param name="rightHandSide">The right hand side.</param>
        internal AndSpecification(ISpecification<T> leftHandSide, ISpecification<T> rightHandSide)
        {
            Check.Require(leftHandSide != null, "leftHandSide cannot be null.");
            Check.Require(rightHandSide != null, "rightHandSide cannot be null.");

            _leftHandSide = leftHandSide;
            _rightHandSide = rightHandSide;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified candidate].
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified candidate]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(T candidate)
        {
            Check.Require(candidate != null, "candidate cannot be null.");

            return _leftHandSide.IsSatisfiedBy(candidate) && _rightHandSide.IsSatisfiedBy(candidate);
        }
    }
}