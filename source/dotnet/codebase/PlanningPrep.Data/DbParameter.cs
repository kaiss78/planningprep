using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PlanningPrep.Core;
using PlanningPrep.Core.Extensions;
using System.Xml;

namespace PlanningPrep.Data
{
    [Serializable]
    public class DbParameter
    {
        private object _value;

        public string Name { get; private set; }

        public DbType? DataType { get; private set; }

        public object Value
        {
            get { return GetNullSafeValue(_value); }
            private set { _value = value; }
        }

        public bool IsOutParameter { get; private set; }

        public int OutParameterSize { get; private set; }

        public DbParameter(string name, object value)
        {
            Name = name;
            _value = value;
        }

        public DbParameter(string name, DbType type, object value)
            : this(name, value)
        {
            DataType = type;
        }

        public DbParameter(string name, object value, bool isOutParameter, int outParameterSize)
        {
            if (isOutParameter)
            {
                Check.Require(outParameterSize >= 0, "");
            }

            Name = name;
            Value = value;
            IsOutParameter = isOutParameter;
            OutParameterSize = outParameterSize;
        }

        public DbParameter(string name, DbType type, object value, bool isOutParameter, int outParameterSize)
            : this(name, value, isOutParameter, outParameterSize)
        {
            DataType = type;
        }


        #region Parameter Value Helper Methods
        private static object GetNullSafeValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            Type paramTypeName = value.GetType();

            if (value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                paramTypeName = value.GetType().GetGenericArguments()[0];
            }

            Type type = DataHelper.ApplicableDataTypes.Keys.SingleOrDefault(k => (k == paramTypeName));

            if (type == typeof(int))
            {
                return ((int)value <= 0) ? (object)DBNull.Value : (int)value;
            }
            if (type == typeof(long))
            {
                return ((long)value <= 0) ? (object)DBNull.Value : (long)value;
            }
            if (type == typeof(decimal))
            {
                return ((decimal)value <= 0) ? (object)DBNull.Value : (decimal)value;
            }
            if (type == typeof(double))
            {
                return ((double)value <= 0) ? (object)DBNull.Value : (double)value;
            }
            if (type == typeof(DateTime))
            {
                return !((DateTime)value).IsValidDateTime() ? (object)DBNull.Value : (DateTime)value;
            }
            if (type == typeof(string))
            {
                return (string.IsNullOrEmpty((string)value)) ? DBNull.Value : value;
            }
            if (type == typeof(int?))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(long))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(decimal))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(double))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(DateTime))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(bool?))
            {
                return !((int?)value).HasValue ? (object)DBNull.Value : ((int?)value).Value;
            }
            if (type == typeof(XmlDocument))
            {
                return (value == null) ? (object)DBNull.Value : ((XmlDocument)value).OuterXml;
            }

            return value ?? DBNull.Value;
        }
        #endregion
    }
}


