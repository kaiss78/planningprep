using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using PlanningPrep.Core.Base.Model;
using PlanningPrep.Core.Exceptions;
using PlanningPrep.Core.Xml;

namespace PlanningPrep.Models.Strategy
{
    /// <summary>
    /// Defines an object that is a strategy object
    /// </summary>
    public class StrategyObject
    {
        static StrategyObject()
        {
            Initialize();
        }

        private static Dictionary<string, Type> _strategyObjects = new Dictionary<string, Type>();
        /// <summary>
        /// 
        /// </summary>
        internal static void Initialize()
        {
            _strategyObjects = new Dictionary<string, Type>();
            Assembly a = Assembly.GetAssembly(typeof(BaseEntity));

            foreach (Type t in a.GetTypes().Where(t => t.IsSubclassOf(typeof (StrategyObject))))
            {
                _strategyObjects.Add(t.Name, t);
            }
        }

        /// <summary>
        /// Deserializes a strategy object for you by guessing the object type
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlDocument source)
        {
            return (T)Deserialize(source);
        }

        /// <summary>
        /// Deserializes a strategy object for you by guessing the object type
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object Deserialize(XmlDocument source)
        {
            if (source == null)
                return null;

            string name;

            switch (source.ChildNodes.Count)
            {
                case 0:
                    return null;
                case 1:
                    name = source.ChildNodes[0].Name;
                    break;
                case 2:
                    name = source.ChildNodes[1].Name;
                    break;
                case 3:
                    name = source.ChildNodes[2].Name;
                    break;
                default:
                    throw new PanthException(string.Format("Unable to deduce strategy object - to many elements:\r\n{0}",source.OuterXml));
            }

            Type t;

            if (!_strategyObjects.TryGetValue(name, out t))
            {
                throw new PanthException(string.Format("Unable to deduce strategy object with first element '{0}'", name));
            }

            return XmlHelper.Deserialize(t, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetTypeFromName(string typeName)
        {
            Type t;

            _strategyObjects.TryGetValue(typeName, out t);

            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategyObject"></param>
        /// <returns></returns>
        public static XmlDocument Serialize(object strategyObject)
        {
            return strategyObject == null ? null : XmlHelper.Serialize(strategyObject);
        }
    }
}