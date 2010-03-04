using System;
using PlanningPrep.Core.Base.Model;
using PlanningPrep.Core.Exceptions;

namespace PlanningPrep.Core.Factories
{
    public sealed class EntityFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public static TEntity Create<TEntity>() where TEntity : BaseEntity
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity));
        }

        public static BaseEntity Create(Type type)
        {
            if (!type.IsSubclassOf(typeof(BaseEntity)))
            {
                throw new PanthException("This type of entity can't be created.");
            }
            return (BaseEntity)Activator.CreateInstance(type);
        }
    }
}


