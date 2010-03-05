using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace App.Core.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the specified type has parameterless contructor..
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// <c>true</c> if parameterless constructor exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasDefaultConstructor(this Type instance)
        {
            Check.Require(instance.IsNotNull(), "instance");
 
            return instance.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Any(ctor => ctor.GetParameters().Length == 0);
        }
 
        /// <summary>
        /// Gets the public types of the given assembly.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        internal static IEnumerable<Type> PublicTypes(this Assembly instance)
        {
            return (instance.IsNull()) ?
                   Enumerable.Empty<Type>() :
                   instance.GetTypes().Where(type => type.IsPublic);
        }
 
        /// <summary>
        /// Gets the public types of the given assemblies.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        internal static IEnumerable<Type> PublicTypes(this IEnumerable<Assembly> instance)
        {
            return (instance.IsNull()) ?
                   Enumerable.Empty<Type>() :
                   instance.SelectMany(assembly => assembly.PublicTypes());
        }
 
        /// <summary>
        /// Gets the concretes types of the given assembly.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        internal static IEnumerable<Type> ConcreteTypes(this Assembly instance)
        {
            return (instance.IsNull()) ?
                   Enumerable.Empty<Type>() :
                   instance.PublicTypes()
                           .Where(type => type.IsClass && !type.IsAbstract && !type.IsInterface && !type.IsGenericType);
        }
 
        /// <summary>
        /// Gets the concretes types of the given assemblies.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        internal static IEnumerable<Type> ConcreteTypes(this IEnumerable<Assembly> instance)
        {
            return (instance.IsNull()) ?
                   Enumerable.Empty<Type>() :
                   instance.SelectMany(assembly => assembly.ConcreteTypes());
        }
    }
}
