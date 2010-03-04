/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: OrSpecification<T>
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
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftHandSide;
        private readonly ISpecification<T> _rightHandSide;

        internal OrSpecification(ISpecification<T> leftHandSide, ISpecification<T> rightHandSide)
        {
            Check.Require(leftHandSide != null, "leftHandSide");
            Check.Require(rightHandSide != null, "rightHandSide");

            _leftHandSide = leftHandSide;
            _rightHandSide = rightHandSide;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            Check.Require(candidate != null, "candidate");

            return _leftHandSide.IsSatisfiedBy(candidate) || _rightHandSide.IsSatisfiedBy(candidate);
        }
    }
}