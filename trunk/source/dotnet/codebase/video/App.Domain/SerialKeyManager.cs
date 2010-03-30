using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Util;

namespace App.Domain
{
    public class SerialKeyManager
    {
        private DbDataContext _Data = null;
        
        public SerialKeyManager()
        {
            _Data = new DbDataContext(ConfigReader.ConnectionString);
        }
        /// <summary>
        /// Cheks whether a Serial Key is exists in the Systems
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyExists(String key)
        {
            SerialKey serialKey = _Data.SerialKeys.SingleOrDefault(S => String.Compare(S.Key, key, false) == 0);
            return serialKey == null ? false : true;
        }
    }
}
