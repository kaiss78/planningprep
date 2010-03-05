using System;
using System.Web;
using App.Core.Extensions;

namespace App.Core.Patterns
{
    public static class Singleton
    {
        public static T GetInstance<T>(string classname) where T : class
        {
            return GetInstance<T>(classname, null);
        }

        public static T GetInstance<T>(string classname, string key) 
            where T : class
        {
            if (HttpContext.Current.IsNull())
            {
                return CreateClass<T>(classname);
            }

            if (key.IsNullOrEmpty())
            {
                key = HttpContext.Current.GetHashCode().ToString("x") + ":" + classname;
            }

            T ret = (T)HttpContext.Current.Items[key];
            if (ret.IsNull())
            {
                ret = CreateClass<T>(classname);
                HttpContext.Current.Items[key] = ret;
            }

            return ret;
        }

        private static T CreateClass<T>(string className)
        {
            return (T)Activator.CreateInstance(Type.GetType(className));
        }
    }
}
