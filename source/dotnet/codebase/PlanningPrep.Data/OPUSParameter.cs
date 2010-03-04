using System;
using System.Data;
using System.Linq;
using Pantheon.Core;
using Pantheon.Core.Extensions;

namespace OPUS.Data
{
    [Serializable]
    public class OPUSParameter
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

        public OPUSParameter(string name, object value)
        {
            Name = name;
            _value = value;
        }

        public OPUSParameter(string name, DbType type, object value)
            : this(name, value)
        {
            DataType = type;
        }

        public OPUSParameter(string name, object value, bool isOutParameter, int outParameterSize)
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

        public OPUSParameter(string name, DbType type, object value, bool isOutParameter, int outParameterSize)
            : this(name, value, isOutParameter, outParameterSize)
        {
            DataType = type;
        }


        #region Parameter Value Helper Methods
        private static object GetNullSafeValue(object value)
        {
            Type type = Type.GetType(DataHelper.ApplicableDataTypes.Keys.SingleOrDefault(k => (k == value.GetType().Name)));

            // Primative Types
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

            // Generic Types
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

            return value ?? DBNull.Value;
        }
        #endregion
    }
}


