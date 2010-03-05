using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Xml;
using App.Core.Base.Model;
using App.Core.Exceptions;
using App.Core;

namespace App.Data
{
    public sealed class DAOFactory
    {
        private static IDictionary<string, KeyValuePair<string, string>> _daosByObjectNameList;

		/// <summary>
		/// Initializes the <see cref="DAOFactory" /> class.
		/// </summary>
        static DAOFactory()
		{
			LoadDAOs();
		}
		/// <summary>
        /// Resolves an instance of IRepository&lt;T&gt; for the provided T as BaseEntity.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IDataAccess<T> Get<T>() where T : BaseEntity
		{
			if (HttpContext.Current != null)
            {
                IPrincipal principal = HttpContext.Current.User;
				if (principal == null) 
                {
					return Get<T>(null);
				}
                return Get<T>(principal);
            }

		    return Get<T>(null);
		}

		/// <summary>
		/// Resolves the specified current user session.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
        public static IDataAccess<T> Get<T>(IPrincipal currentUser) where T : BaseEntity
		{
		    IDataAccess<T> newDAO;
			if (_daosByObjectNameList == null) 
            {
                LoadDAOs();
			}

            Check.Ensure(_daosByObjectNameList != null, "DAOs to Objects list cann't be null. Make sure that the DataAccessObjects configuration file is step up correctly.");

			string assmbly = _daosByObjectNameList[ typeof(T).Name ].Key;
			string typeName = _daosByObjectNameList[ typeof(T).Name ].Value;
                       
            Type daoType = Type.GetType(typeName + ", " + assmbly);


            //newDAO = daoType == typeof(OpusStepDAO<>)
            //             ? (IDataAccess<T>)Activator.CreateInstance(daoType.MakeGenericType(new[] { typeof(T) }))
            //             : (IDataAccess<T>)Activator.CreateInstance(daoType);

		    newDAO = (IDataAccess<T>) Activator.CreateInstance(daoType);

		    if (currentUser != null)
            {
                newDAO.CurrentUser = currentUser;
			}

            return newDAO;
		}

		/// <summary>
        /// Loads the DAOs.
		/// </summary>
        static void LoadDAOs()
		{
			if (_daosByObjectNameList == null) 
            {              
				_daosByObjectNameList = new Dictionary<string, KeyValuePair<string, string>>();
                XmlDocument daoDoc = new XmlDocument();

				try 
                {
					using (Stream Reader = Assembly.GetExecutingAssembly().GetManifestResourceStream("App.Data.DataAccessObjects.xml")) 
                    {
						daoDoc.Load(Reader);
					}

					foreach (XmlNode obj in daoDoc.SelectNodes("//entity-daos/entity"))
                    {
						string objectName = obj.Attributes["name"].Value;
						string[] typeArgs = obj.Attributes["daoType"].Value.Split(',');

						if (!_daosByObjectNameList.Keys.Contains(objectName)) 
                        {
							_daosByObjectNameList.Add(objectName, new KeyValuePair<string, string>(typeArgs.GetValue(1).ToString(), (typeArgs.GetValue(0).ToString())));
						}

					}
				}
				catch (Exception ex) 
                {
                    Exception exToUse = ex.InnerException ?? ex;
                    throw new PanthException(exToUse.Message, exToUse);
				}
			}
		}
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		[DebuggerStepThrough]
		public static void Initialize()
		{
            LoadDAOs();
		}
    }
}


