/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: Specification<T>
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
using System.Linq;
using System.Linq.Expressions;

namespace App.Core.BusinessRuleEngine.Specification
{
    /// <summary>
    /// Provides a default implementation of the <see cref="ISpecification{TEntity}"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="Specification{TEntity}"/> implements Composite Specification pattern by overloading
    /// the &amp; and | (And, Or in VB.Net) operators to allow composing multiple specifications together.
    /// </remarks>
    public class Specification<T> : ISpecification<T>
    {
        #region fields
        private readonly Expression<Func<T, bool>> _predicate;
        private readonly Func<T, bool> _predicateCompiled;
        #endregion

        #region .ctor
        public Specification() {}

        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression.
        /// </summary>
        /// <param name="predicate">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        public Specification(Expression<Func<T, bool>> predicate)
        {
            Check.Require(predicate != null, "Expected a non null expression as a predicate for the specification.");
            _predicate = predicate;
            _predicateCompiled = predicate.Compile();
        }

        #endregion

        #region implementation of ISpecification<TEntity>

        /// <summary>
        /// Gets the expression that encapsulates the criteria of the specification.
        /// </summary>
        public Expression<Func<T, bool>> Predicate
        {
            get { return _predicate; }
        }

        /// <summary>
        /// Evaluates the specification against an entity of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="T"/> instance to evaluate the specificaton
        /// against.</param>
        /// <returns>Should return true if the specification was satisfied by the entity, else false. </returns>
        public virtual bool IsSatisfiedBy(T entity)
        {
            return _predicateCompiled.Invoke(entity);
        }

        #endregion

        #region operator overloads

        /// <summary>
        /// Overloads the &amp; operator and combines two <see cref="Specification{TEntity}"/> in a Boolean And expression
        /// and returns a new see cref="Specification{TEntity}"/>.
        /// </summary>
        /// <param name="leftHand">The left hand <see cref="Specification{TEntity}"/> to combine.</param>
        /// <param name="rightHand">The right hand <see cref="Specification{TEntity}"/> to combine.</param>
        /// <returns>The combined <see cref="Specification{TEntity}"/> instance.</returns>
        public static Specification<T> operator &(Specification<T> leftHand, Specification<T> rightHand)
        {
            var rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());
            var newExpression = Expression.MakeBinary(ExpressionType.AndAlso, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>( Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters) );
        }
        
        /// <summary>
        /// Overloads the &amp; operator and combines two <see cref="Specification{TEntity}"/> in a Boolean Or expression
        /// and returns a new see cref="Specification{TEntity}"/>.
        /// </summary>
        /// <param name="leftHand">The left hand <see cref="Specification{TEntity}"/> to combine.</param>
        /// <param name="rightHand">The right hand <see cref="Specification{TEntity}"/> to combine.</param>
        /// <returns>The combined <see cref="Specification{TEntity}"/> instance.</returns>
        public static Specification<T> operator |(Specification<T> leftHand, Specification<T> rightHand)
        {
            var rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());
            var newExpression = Expression.MakeBinary(ExpressionType.OrElse, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>( Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }


        /// <summary>
        /// Ands the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }


        /// <summary>
        /// Ors the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        #endregion
    }
}