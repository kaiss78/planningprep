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
using System.Data;
using OPUS.Models.Enums;
using Pantheon.Core.DB;
using Pantheon.Core.Factories;

namespace OPUS.Data.HistoryData
{
    public class HistoryDataDAO : BaseDataAccess<Models.HistoryData.HistoryData>, IHistoryDataDAO
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
        protected override Models.HistoryData.HistoryData Map(IDataReader reader)
        {
            Models.HistoryData.HistoryData entity = EntityFactory.Create<Models.HistoryData.HistoryData>();

            entity.Id = NullHandler.GetLong(reader["id"]);
            entity.ProjectID = NullHandler.GetLong(reader["ProjectId"]);
            entity.HistoryType = NullHandler.GetEnum<HistoryType>(reader["HistoryType"]);
            entity.FieldName = NullHandler.GetString(reader["FieldName"]);
            entity.SQLFieldTypeCode = NullHandler.GetEnum<OPUSDbType>(reader["SQLFieldTypeCode"]);
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
        protected override void EagerLoad(Models.HistoryData.HistoryData entity)
        {
            // Add eager loading functionality here
        }

        /// <summary>
        /// Saves the reference properties before.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesBefore(Models.HistoryData.HistoryData entity)
        {
        }

        /// <summary>
        /// Saves the reference properties after.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void SaveReferencePropertiesAfter(Models.HistoryData.HistoryData entity)
        {
        }

        #endregion
    }
}