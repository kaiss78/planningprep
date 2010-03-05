using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace App.Data
{
    internal sealed class DataHelper
    {
        internal static IDictionary<Type, DbType> ApplicableDataTypes
        {
            get
            {
                return new Dictionary<Type, DbType>
                           {
                               {typeof (Int16), DbType.Int16},
                               {typeof (int), DbType.Int32},
                               //{typeof (Int32), DbType.Int32},
                               {typeof (long), DbType.Int64},
                               //{typeof (Int64), DbType.Int64},
                               {typeof (double), DbType.Decimal},
                               //{typeof (float), DbType.Single},
                               {typeof (decimal), DbType.Decimal},
                               {typeof (Single), DbType.Single},
                               {typeof (DateTime), DbType.DateTime},
                               {typeof (bool), DbType.Boolean},
                               {typeof (string), DbType.String},
                               {typeof (byte[]), DbType.Binary},
                               {typeof (object), DbType.Binary},
                               //{typeof (Nullable<int>), DbType.Int32},
                               //{typeof (Nullable<long>), DbType.Int64},
                               //{typeof (Nullable<decimal>), DbType.Decimal},
                               //{typeof (Nullable<DateTime>), DbType.DateTime},
                               //{typeof (Nullable<bool>), DbType.Boolean},
                               {typeof (XmlDocument), DbType.Xml}
                           };
            }

        }
    }
}


