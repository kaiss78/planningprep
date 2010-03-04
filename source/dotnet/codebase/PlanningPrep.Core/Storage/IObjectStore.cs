using System.Collections.Generic;

namespace PlanningPrep.Core.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObjectStore
    {
        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Delete(string key);
        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="searchString">The search string.</param>
        void Delete(string key, string searchString);
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class, new();
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        T Get<T>(string key, string searchString) where T : class, new();
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        IList<T> GetList<T>(string key) where T : class, new();
        /// <summary>
        /// Stores the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="value">The value.</param>
        void Store<T>(string key, string searchString, T value) where T : class, new();
        /// <summary>
        /// Stores the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Store<T>(string key, T value) where T : class, new();
    }
}