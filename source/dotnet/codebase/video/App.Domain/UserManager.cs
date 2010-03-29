using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using App.Util;
using App.Data;

namespace App.Domain
{
    public class UserManager
    {
        private DbDataContext _Data = null;

        public UserManager()
        {
            _Data = new DbDataContext(ConfigReader.ConnectionString);
        }
        /// <summary>
        /// Gets a Site User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SiteUser GetByID(long id)
        {
            if (_Data.SiteUsers.Count() == 0)
                return null;
            return _Data.SiteUsers.Single(U => U.UserID == id);
        }
        /// <summary>
        /// Gets a Site User by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public SiteUser GetByUserByEmail(String email)
        {
            if (_Data.SiteUsers.Count() == 0)
                return null;
            return _Data.SiteUsers.Single(U => String.Compare(U.Email, email, true) == 0); 
        }
        /// <summary>
        /// Gets a Site User by Serial Key
        /// </summary>
        /// <param name="serialKey"></param>
        /// <returns></returns>
        public SiteUser GetByUserBySerialKey(String serialKey)
        {
            if (_Data.SiteUsers.Count() == 0)
                return null;
            return _Data.SiteUsers.Single(U => String.Compare(U.SerialKey, serialKey, true) == 0);
        }
        /// <summary>
        /// Saves User Information 
        /// </summary>
        /// <param name="user"></param>
        public void Save(SiteUser user)
        {
            if (user != null)
            {
                if (user.UserID == 0)
                {
                    user.Created = DateTime.Now;
                    user.Modified = DateTime.Now;
                }
                else
                    user.Modified = DateTime.Now;

                _Data.SiteUsers.InsertOnSubmit(user);
                _Data.SubmitChanges();
            }
        }
    }
}
