#region History

/* --------------------------------------------------------------------------------
 * Client Name: National Quality Forum
 * Project Name: OPLM
 * Module: OPLM.DAL
 * Name: DataAccess.cs
 * Purpose: for ClassTemplate related work
 *                   
 * Author: HA
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  09/30/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using App.Core;
using App.Core.Base;
using App.Core.Base.Model;
using App.Core.DB;
using App.Core.Exceptions;
using App.Core.Extensions;
using System.Reflection;
using App.Core.Logging;

namespace App.Data
{
    /// <summary>
    /// Contains the function related to database access
    /// </summary>
    public abstract class BaseDataAccess<TEntity> : DisposableBase, IDataAccess<TEntity>
        where TEntity : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Gets Database information
        /// </summary>
        protected internal Database Database
        {
            get;
            private set;
        }

        public IPrincipal CurrentUser
        {
            get;
            set;
        }
        #endregion

        #region Constructer & Destructer
        protected BaseDataAccess()
        {
            Database = DatabaseFactory.CreateDatabase("App.DbConnection");
        }

        protected BaseDataAccess(string connectionString)
        {
            Check.Require( !string.IsNullOrEmpty(connectionString), "The connection string must be supplied to instantiated this data access object (DAO).");
            Database = DatabaseFactory.CreateDatabase(connectionString);
        }

        protected override void DisposeInternal()
        {
            if (Database.IsNotNull())
            {
                Database = null;
            }
            base.DisposeInternal();
        }
        #endregion

        #region Protected Methods
        #region Internal Methods
        /// <summary>
        /// Gets the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected internal TEntity GetInternal(string storedProc, DbParameter[] parameters)
        {
            return GetInternal(storedProc, parameters, false);
        }
        /// <summary>
        /// Gets the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        protected internal TEntity GetInternal(string storedProc, DbParameter[] parameters, bool eagerLoad)
        {
            Check.Require(!string.IsNullOrEmpty(storedProc), "");

            TEntity foundModel = null;

            using (DbCommand command = Database.GetStoredProcCommand(storedProc))
            {
                if (parameters.IsNotNull())
                {
                    SetParameters(command, parameters);
                }

                using (IDataReader reader = ExecuteReader(command))
                {
                    if(reader.IsNotNull())
                    {
                        while (reader.Read())
                        {
                            foundModel = Map(reader);
                        }
                        reader.Close();
                    }
                }
            }

            if(eagerLoad)
            {
               EagerLoad(foundModel); 
            }

            return foundModel;
        }
        /// <summary>
        /// Gets all internal.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        protected internal List<TEntity> GetAllInternal(string storedProcedure, bool eagerLoad)
        {
            Check.Require(!string.IsNullOrEmpty(storedProcedure), "");

            List<TEntity> foundModelList = new List<TEntity>();

            using (DbCommand command = Database.GetStoredProcCommand(storedProcedure))
            {
                using (IDataReader reader = ExecuteReader(command))
                {
                    if (reader.IsNotNull())
                    {
                        while(reader.Read())
                        {
                            TEntity foundModel = Map(reader);
                            if(foundModel.IsNotNull() && !foundModelList.Contains(foundModel))
                            {
                                foundModelList.Add(foundModel);
                            }
                        }
                        reader.Close();
                    }
                }
            }

            if (eagerLoad)
            {
                foundModelList.ForEach(EagerLoad);
            }

            return foundModelList;
        }
        /// <summary>
        /// Gets all internal.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        protected internal List<TEntity> GetAllInternal(string storedProcedure, DbParameter[] parameters, bool eagerLoad)
        {
            Check.Require(!string.IsNullOrEmpty(storedProcedure), "");

            List<TEntity> foundModelList = new List<TEntity>();

            using (DbCommand command = Database.GetStoredProcCommand(storedProcedure))
            {
                if (parameters.IsNotNull())
                {
                    SetParameters(command, parameters);
                }

                using (IDataReader reader = ExecuteReader(command))
                {
                    if (reader.IsNotNull())
                    {
                        while (reader.Read())
                        {
                            TEntity foundModel = Map(reader);
                            if (foundModel.IsNotNull() && !foundModelList.Contains(foundModel))
                            {
                                foundModelList.Add(foundModel);
                            }
                        }
                        reader.Close();
                    }
                }
            }

            if (eagerLoad)
            {
                foundModelList.ForEach(EagerLoad);
            }

            return foundModelList;
        }
        /// <summary>
        /// Saves the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected internal object SaveInternal(string storedProc, IEnumerable<DbParameter> parameters /*, DbTransaction transaction*/)
        {
            Check.Require(!string.IsNullOrEmpty(storedProc), "");

            using (DbCommand command = Database.GetStoredProcCommand(storedProc))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 90;

                if (parameters.IsNotNull())
                {
                    SetParameters(command, parameters);
                }

                object returnValue;
                //returnValue = Database.ExecuteNonQuery(command); 
                returnValue = Database.ExecuteScalar(command);

                if (parameters.IsNotNull() && parameters.Any(p => p.IsOutParameter))
                {
                    DbParameter param = parameters.FirstOrDefault(p => p.IsOutParameter);
                    if (param.IsNotNull())
                    {
                        switch (param.Name.ToUpper())
                        {
                            case "RETURNCODE":
                                returnValue = GetReturnCodeFromParameter<object>(command);
                                break;
                            case "GENERATEDID":
                                returnValue = GetGeneratatedIdFromParameter<object>(command);
                                break;
                            case "ID":
                                returnValue = GetNewIdFromParameter<object>(command);
                                break;
                        }
                    }
                }
                return returnValue;
            }
        }
        /// <summary>
        /// Deletes the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        protected internal bool DeleteInternal(string storedProc, DbParameter parameter /*, DbTransaction transaction*/)
        {
            Check.Require(!string.IsNullOrEmpty(storedProc), "");

            using (DbCommand command = Database.GetStoredProcCommand(storedProc))
            {
                if (parameter.IsNotNull())
                {
                    SetParameters(command, new[] {parameter});
                }

                //if (transaction == null)
                //{
                return (Database.ExecuteNonQuery(command) > 0);
                //}
                //return (Database.ExecuteNonQuery(command, transaction) > 0);
            }
        }
        /// <summary>
        /// Deletes the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected internal bool DeleteInternal(string storedProc, DbParameter[] parameters)
        {
            return DeleteInternal(storedProc, parameters, null);
        }
        /// <summary>
        /// Deletes the internal.
        /// </summary>
        /// <param name="storedProc">The stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        protected internal bool DeleteInternal(string storedProc, DbParameter[] parameters, DbTransaction transaction)
        {
            Check.Require(!string.IsNullOrEmpty(storedProc), "");

            using (DbCommand command = Database.GetStoredProcCommand(storedProc))
            {
                if (parameters.IsNotNull())
                {
                    SetParameters(command, parameters);
                }

                if (transaction == null)
                {
                    return (Database.ExecuteNonQuery(command) > 0);
                }
                return (Database.ExecuteNonQuery(command, transaction) > 0);
            }
        }
        #endregion

        #region Database Methods
        /// <summary>
        /// Exectures Query returns IDataReader
        /// </summary>
        /// <param name="cmd">Contains the database command</param>
        /// <returns>Contains data reader</returns>
        protected virtual IDataReader ExecuteReader(DbCommand cmd)
        {
            return Database.ExecuteReader(cmd);
        }
        /// <summary>
        /// Exectures Query returns Updated Records
        /// </summary>
        /// <param name="cmd">Contains the database command</param>
        /// <returns>Contains command execution status</returns>
        protected virtual int ExecuteNonQuery(DbCommand cmd)
        {
            return Database.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        protected virtual int ExecuteNonQuery(DbCommand cmd, DbTransaction transaction)
        {
            return Database.ExecuteNonQuery(cmd, transaction);
        }
        /// <summary>
        /// Exectures Query returns Object
        /// </summary>
        /// <param name="command">Contains the database command</param>
        /// <returns>Contains the value after executed the database command</returns>
        protected TType ExecuteScalar<TType>(DbCommand command)
        {
            return (TType)Database.ExecuteScalar(command);
        }
        /// <summary>
        /// Returns Parameter Codes
        /// </summary>
        /// <param name="command">Contains the database command</param>
        /// <returns></returns>
        protected TType GetReturnCodeFromParameter<TType>(DbCommand command)
        {
            return (TType)Database.GetParameterValue(command, "@ReturnCode");
        }
        /// <summary>
        /// Gets the generatated id from parameter.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        protected TType GetGeneratatedIdFromParameter<TType>(DbCommand command)
        {
            return command.Parameters["@GeneratedID"].Value == DBNull.Value ? default(TType) : (TType)command.Parameters["@GeneratedID"].Value;
        }
        /// <summary>
        ///  Gets Id From Parameter
        /// </summary>
        /// <param name="command">Contains the database command</param>
        /// <returns></returns>
        protected virtual TType GetNewIdFromParameter<TType>(DbCommand command)
        {
            return (TType)Database.GetParameterValue(command, "@ID");
        }
        /// <summary>
        /// Gets Total Row from Parameter
        /// </summary>
        /// <param name="command">Contains the database command</param>
        /// <returns></returns>
        protected virtual int GetTotalRowFromParameter(DbCommand command)
        {
            return (int)Database.GetParameterValue(command, "@TotalRow");
        }
        /// <summary>
        /// Gets Count From Parameter
        /// </summary>
        /// <param name="command">Contains the database command</param>
        /// <returns></returns>
        protected virtual int GetCountFromParameter(DbCommand command)
        {
            return (int)Database.GetParameterValue(command, "@Count");
        }
        #endregion

        #region Abstract Methods
        /// <summary>
        /// Maps and sets the Entity Model from the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        protected abstract TEntity Map(IDataReader reader);
        /// <summary>
        /// Eager load entity model reference properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected abstract void EagerLoad(TEntity entity);
        #endregion

        #region Virtual Methods
        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void SaveReferencePropertiesBefore(TEntity entity)
        { }
        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void SaveReferencePropertiesAfter(TEntity entity)
        {}
        #endregion
        #endregion

        #region Public Methods
        /// <summary>
        /// For getting the connection from BL
        /// </summary>
        /// <returns>Connection</returns>
        public DbConnection GetConnection()
        {
            return Database.CreateConnection();
        }

        #region Virtual Methods
        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual TEntity Get(long id)
        {
            return Get(id, false);
        }
        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public virtual TEntity Get(long id, bool eagerLoad)
        {
            using (new TimedTraceLog(CurrentUser.IsNotNull() ? CurrentUser.Identity.Name : "", GetType().Name + ".Get(long,bool)"))
            {
                TEntity entity = default(TEntity);
                try
                {
                    Check.Require(id > 0, "Can't get an entity with a invalid id.");

                    DbParameter[] parameters = new[] { new DbParameter("Id", DbType.Int64, id) };

                    entity = GetInternal("sp" + GetEntityMappedNameForSP(typeof(TEntity).Name) + "GetById", parameters, eagerLoad);
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".Get(long,bool)");
                }
                return entity;
            }
        }
        /// <summary>
        /// Gets the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public virtual TEntity Get(Func<TEntity, bool> query)
        {
            return Get(query, false);
        }
        /// <summary>
        /// Gets the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public virtual TEntity Get(Func<TEntity, bool> query, bool eagerLoad)
        {
            return GetAll(eagerLoad).FirstOrDefault(query);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public virtual List<TEntity> GetAll(Func<TEntity, bool> query)
        {
            return GetAll(query, false);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public virtual List<TEntity> GetAll(Func<TEntity, bool> query, bool eagerLoad)
        {
            return GetAll(eagerLoad).Where(query).ToList();
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public virtual List<TEntity> GetAll(bool eagerLoad)
        {
            using (new TimedTraceLog(CurrentUser.IsNotNull() ? CurrentUser.Identity.Name : "", GetType().Name + ".GetAll(bool)"))
            {
                List<TEntity> entities = new List<TEntity>();
                try
                {
                    entities = GetAllInternal("sp" + GetEntityMappedNameForSP(typeof(TEntity).Name) + "GetAll", eagerLoad);
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".GetAll(bool)");
                }
                return entities;
            }
        }
        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public virtual List<TEntity> GetPagedList(Func<TEntity, bool> query, int page, int pageSize)
        {
            return GetAll(query, false).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// Maps Entity name to build SP name
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        private string GetEntityMappedNameForSP(string entityName)
        {
            if (entityName == "PlanningPrepUser")
            {
                return "Author";
            }
            if (entityName == "ExamSaved")
            {
                return "ExamsSaved";
            }
            return entityName;
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Save(TEntity entity)
        {
            using (new TimedTraceLog(CurrentUser.IsNotNull() ? CurrentUser.Identity.Name : "Unknown User", GetType().Name + ".Save(" + typeof(TEntity).Name + ")"))
            {
                try
                {
                    Check.Require(entity.IsNotNull(), string.Format("Can't save a null {0} entity.", typeof(TEntity).Name));

                    // clean entity object before save
                    entity.CleanBeforeSave();
                    // save any reference properties before save
                    SaveReferencePropertiesBefore(entity);
                    // Create parmaters automatically
                    IEnumerable<DbParameter> parameters = AutoCreateParametersFromEntityMetadata(entity);
                    // Save
                    object returnValue = SaveInternal("sp" + GetEntityMappedNameForSP(typeof(TEntity).Name) + "Set", parameters);
                    // If new, set enity object Id
                    if (entity.IsNew && returnValue.IsNumeric())
                    {
                        entity.Id = Convert.ToInt64(returnValue);
                    }

                    // save any reference properties after save
                    SaveReferencePropertiesAfter(entity);

                    // Save history Data
                    //HistoryEntity historyEntity = entity as HistoryEntity;
                    //if (historyEntity.IsNotNull() && historyEntity.IsNotNull())
                    //{
                    //    SaveHistoryData(historyEntity.HistoryDataList);
                    //}
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".Save(" + typeof(TEntity).Name + ")");
                }
            }
        }
        /// <summary>
        /// Saves all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void SaveAll(IList<TEntity> entities)
        {
            entities.ForEach(e => Save(e));
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual bool Delete(TEntity entity)
        {
            using (new TimedTraceLog(CurrentUser.IsNotNull() ? CurrentUser.Identity.Name : "Unknown User", GetType().Name + ".Delete(" + typeof(TEntity).Name + ")"))
            {
                try
                {
                    Check.Require(entity.IsNotNull(), string.Format("Can't delete a null {0} entity.", typeof(TEntity).Name));

                    return DeleteInternal("sp" + typeof(TEntity).Name + "Delete", new DbParameter("Id", DbType.Int64, entity.Id));
                }
                catch (Exception ex)
                {
                    Exception excToUse = ex.InnerException ?? ex;
                    throw new DataAccessException(excToUse.Message, excToUse, GetType().Name + ".Delete(" + typeof(TEntity).Name + ")");
                }
            }
        }
        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public bool DeleteAll(IList<TEntity> entities)
        {
            bool result = false;
            entities.ForEach(e => result = Delete(e));
            return result;
        }
        #endregion
        #endregion

        #region Internal Methods
        /// <summary>
        /// Gets the type of the db.
        /// </summary>
        /// <param name="dataTypeName">Name of the data type.</param>
        /// <returns></returns>
        internal static DbType GetDbType(string dataTypeName)
        {
            Type dataType = Type.GetType(dataTypeName);
            Check.Ensure(DataHelper.ApplicableDataTypes.ContainsKey(dataType), "The type \"" + dataTypeName + "\" cannot be resolved. Did you check the configuration?");

            return DataHelper.ApplicableDataTypes[dataType];
        }
        /// <summary>
        /// Sets the parameters.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        internal void SetParameters(DbCommand command, IEnumerable<DbParameter> parameters)
        {
            foreach (DbParameter parameter in parameters)
            {
                if(typeof(BaseEntity).IsAssignableFrom(parameter.Value.GetType()) || typeof(IList<>).IsAssignableFrom(parameter.Value.GetType()) || typeof(IEnumerable<>).IsAssignableFrom(parameter.Value.GetType()))
                {
                    continue;
                }
                

                DbType type = parameter.DataType.HasValue ? parameter.DataType.Value : GetDbType(parameter.Value.GetType().FullName);

                string parameterName = Database.BuildParameterName(parameter.Name); //string.Format("@{0}", parameter.Name);
                if (!parameter.IsOutParameter)
                {
                    Database.AddInParameter(command, parameterName, type, parameter.Value);
                }
                else
                {
                    Database.AddOutParameter(command, parameterName, type, parameter.OutParameterSize);
                }
            }
        }
        /// <summary>
        /// Autoes the create parameters from entity metadata.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal IEnumerable<DbParameter> AutoCreateParametersFromEntityMetadata(TEntity entity)
        {
            Check.Require(entity.IsNotNull(), "Can't auto create parameters for entity");

            return from property in entity.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance | BindingFlags.Default )
                   where !property.PropertyType.IsSubclassOf( typeof( BaseEntity ) ) && !property.PropertyType.IsGenericType
                   let exclusionAttributes = property.GetCustomAttributes(typeof (ParameterExclusionAttribute), true) as ParameterExclusionAttribute[]
                   where exclusionAttributes == null || exclusionAttributes.Count() <= 0
                   let dbType = GetDbType(property.PropertyType.FullName)
                   let paramName = property.Name
                   select new DbParameter( paramName, dbType, property.GetValue( entity, null ) );
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Handles the data access exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionSource">The exception source.</param>
        protected void HandleDataAccessException(Exception exception, string exceptionSource)
        {
            Exception excToUse = exception.InnerException ?? exception;
            AppLogger.HandleException(excToUse);
            throw new DataAccessException(excToUse.Message, excToUse, exceptionSource);
        }
        #endregion

        //#region HistoryData Methods
        ///// <summary>
        ///// Saves the history data.
        ///// </summary>
        ///// <param name="historyDataList">The history data list.</param>
        //private static void SaveHistoryData(List<HistoryData> historyDataList)
        //{
        //    using(IHistoryDataDAO dao = (IHistoryDataDAO) DAOFactory.Get<HistoryData>())
        //    {
        //        dao.SaveAll(historyDataList);
        //    }
        //}
        //#endregion
    }
}


