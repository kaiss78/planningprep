#region File Info/History

/*
 * --------------------------------------------------------------------------------
 * Project Name: [Project Name]
 * Module: [Assembly Name]
 * Name: HistoryData.cs
 * Purpose: DAO Class to get/set the data from HistoryData Table
 * 
 * Author: [Developer Name]
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * User					Date					Comments
 * [Developer Name]		01/08/2010 07:33:50		Initial Development
 * -------------------------------------------------------------------------------- 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using App.Models.Enums;
using App.Models.History;
using App.Core;
using App.Core.Base.Model;
using App.Core.DB;
using App.Core.Extensions;
using App.Core.Factories;

namespace App.Data.History
{
    public class HistoryDataDAO : BaseDataAccess<HistoryData>, IHistoryDataDAO
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataDAO"/> class.
        /// </summary>
        public HistoryDataDAO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataDAO"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public HistoryDataDAO(string connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Maps and sets the Entity Model from the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        protected override HistoryData Map(IDataReader reader)
        {
            HistoryData entity = EntityFactory.Create<HistoryData>();

            entity.Id = NullHandler.GetLong(reader["id"]);
            entity.ProjectId = NullHandler.GetLong(reader["ProjectId"]);
            entity.HistoryType = NullHandler.GetEnum<HistoryType>(reader["HistoryType"]);
            entity.FieldName = NullHandler.GetString(reader["FieldName"]);
            entity.SQLFieldTypeCode = NullHandler.GetEnum<PantheonDbType>(reader["SQLFieldTypeCode"]);
            entity.BeforeValue = NullHandler.GetObject(reader["BeforeValue"]);
            entity.AfterValue = NullHandler.GetObject(reader["AfterValue"]);
            entity.UserID = NullHandler.GetLong(reader["UserId"]);
            entity.UserName = NullHandler.GetString(reader["UserName"]);
            entity.RecordID = NullHandler.GetLong(reader["RecordId"]);
            entity.ReasonForChange = NullHandler.GetString(reader["ReasonForChange"]);
            entity.DatetimeStamp = NullHandler.GetDateTime(reader["DateTimestamp"]);

            return entity;
        }

        /// <summary>
        /// Eagers the load.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void EagerLoad(HistoryData entity)
        {
            // Add eager loading functionality here
        }

        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesBefore(HistoryData entity)
        {
        }

        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesAfter(HistoryData entity)
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the history for record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recordId">The record id.</param>
        /// <returns></returns>
        public List<HistoryData> GetAllForRecord<T>(long recordId)
            where T : BaseEntity
        {
            using (new TimedTraceLog(CurrentUser.IsNotNull() ? CurrentUser.Identity.Name : "", GetType().Name + ".GetAllForRecord<" + typeof(T).Name + ">(long)"))
            {
                List<HistoryData> historyData = new List<HistoryData>();
                try
                {
                    Check.Require(recordId > 0, "Can't get an history data for {0} with a invalid  record id.".ToInvariantFormat(typeof(T).Name));

                    DbParameter[] parameters = new[] { new DbParameter("HistoryType", DbType.String, typeof(T).Name), new DbParameter("RecordId", DbType.Int64, recordId) };

                    historyData = GetAllInternal("spHistoryDataGetAllForRecord", parameters, false);
                }
                catch (Exception ex)
                {
                    HandleDataAccessException(ex, GetType().Name + ".GetAllForRecord<" + typeof(T).Name + ">(long");
                }
                return historyData;
            }
        }
        #endregion
    }
}