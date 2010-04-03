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

        /// <summary>
        /// Saves key Information 
        /// </summary>
        /// <param name="user"></param>
        public void Save(string strKey)
        {
            if (strKey != null && !IsKeyExists(strKey))
            {
                SerialKey key = new SerialKey();
                key.Key = strKey;
                key.Created = DateTime.Now;
                _Data.SerialKeys.InsertOnSubmit(key);
                _Data.SubmitChanges();
            }
        }
    }
}
