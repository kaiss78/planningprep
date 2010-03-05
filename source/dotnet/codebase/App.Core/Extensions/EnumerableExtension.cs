/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: EnumerableExtension
 * Purpose: Extension class for IEnumerable<T>
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/13/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace App.Core.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// ForEach extension that enumerates over all items in an <see cref="IEnumerable{T}"/> and executes 
        /// an action.
        /// </summary>
        /// <typeparam name="T">The type that this extension is applicable for.</typeparam>
        /// <param name="collection">The enumerable instance that this extension operates on.</param>
        /// <param name="action">The action executed for each iten in the enumerable.</param>
        public static void ForEach<T>( this IEnumerable<T> collection, Action<T> action )
        {
            foreach ( T item in collection )
                action( item );
        }

        /// <summary>
        /// ForEach extension that enumerates over all items in an <see cref="IEnumerator{T}"/> and executes 
        /// an action.
        /// </summary>
        /// <typeparam name="T">The type that this extension is applicable for.</typeparam>
        /// <param name="collection">The enumerator instance that this extension operates on.</param>
        /// <param name="action">The action executed for each iten in the enumerable.</param>
        public static void ForEach<T>( this IEnumerator<T> collection, Action<T> action )
        {
            while ( collection.MoveNext() )
                action( collection.Current );
        }

        /// <summary>
        /// Converts an <see cref="IEnumerator{T}"/> to a <see cref="IQueryable{T}"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static IQueryable ToQueryable( this IEnumerable collection )
        {
            return collection.AsQueryable();
        }

        /// <summary>
        /// Removes the duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static List<T> RemoveDuplicates<T>(this IEnumerable<T> input)
        {
            Dictionary<T, int> uniqueStore = new Dictionary<T, int>();
            List<T> finalList = new List<T>();

            foreach (T currValue in input.Where(currValue => !uniqueStore.ContainsKey(currValue)))
            {
                uniqueStore.Add(currValue, 0);
                finalList.Add(currValue);
            }
            return finalList;
        }
    }
}
