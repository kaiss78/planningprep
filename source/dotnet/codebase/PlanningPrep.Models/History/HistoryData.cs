#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.Common
 * Name: HistoryData.cs
 * Purpose: Entity class for HistoryData
 *                   
 * Author: AFS
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  10/14/2009
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

#region References

using System;
using PlanningPrep.Models.Enums;
using PlanningPrep.Core.Base.Model;
using PlanningPrep.Core.DB;
using System.Data;
using PlanningPrep.Core.Extensions;
using PlanningPrep.Core.Factories;

#endregion

namespace PlanningPrep.Models.History
{
    [Serializable]
    public class HistoryData : BaseEntity
    {
        /// <summary>
        /// Creates the new Entity object with modified data.
        /// </summary>
        /// <returns></returns>
        public static HistoryData CreateNewWithModifiedData(HistoryType historyType, string fieldName, PlanningPrepDbType sqlFieldTypeCode, object beforeValue, object afterValue, long recordId, long projectId, string reasonForChange)
        {
            HistoryData historyData = EntityFactory.Create<HistoryData>();

            historyData.HistoryType = historyType;
            historyData.FieldName = fieldName;
            historyData.SQLFieldTypeCode = sqlFieldTypeCode;
            historyData.BeforeValue = beforeValue;
            historyData.AfterValue = afterValue;
            historyData.RecordID = recordId;
            historyData.ProjectId = projectId;
            historyData.ReasonForChange = reasonForChange;

            return historyData;
        }

        /// <summary>
        /// Creates an user from DataReader
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static HistoryData CreateFromDataReader(IDataReader reader)
        {
            HistoryData historyData = EntityFactory.Create<HistoryData>();

            historyData.Id = NullHandler.GetLong(reader["HistoryID"]);
            historyData.ProjectId = NullHandler.GetLong(reader["ProjectID"]);
            historyData.HistoryType = NullHandler.GetEnum<HistoryType>(reader["DataTypeName"]);
            historyData.FieldName = NullHandler.GetString(reader["FieldName"]); 
            historyData.ReasonForChange = NullHandler.GetString(reader["ReasonForChange"]);
            historyData.SQLFieldTypeCode = NullHandler.GetEnum<PlanningPrepDbType>(reader["SQLFieldTypeCode"]);
            historyData.BeforeValue = reader["BeforeValue"];
            historyData.AfterValue = reader["AfterValue"];
            historyData.UserID = NullHandler.GetLong(reader["UserID"]);
            historyData.UserName = NullHandler.GetString(reader["UserName"]);
            historyData.RecordID = NullHandler.GetLong(reader["RecordID"]);
            historyData.DatetimeStamp = NullHandler.GetDateTime(reader["DateTimeStamp"]);

            return historyData;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the ProjectID
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the HistoryType
        /// </summary>
        public HistoryType HistoryType { get; set; }

        /// <summary>
        /// Gets or sets the FieldName
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the SQLFieldTypeCode
        /// </summary>
        public PlanningPrepDbType SQLFieldTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the BeforeValue
        /// </summary>
        public object BeforeValue { get; set; }

        /// <summary>
        /// Gets or sets the AfterValue
        /// </summary>
        public object AfterValue { get; set; }

        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the DataID
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// Gets or sets the ReasonForChange
        /// </summary>
        public string ReasonForChange { get; set; }

        #endregion

        public override void CleanBeforeSave()
        {
            base.CleanBeforeSave();

            if (SQLFieldTypeCode == PlanningPrepDbType.DbTypeDateTime)
            {
                if (BeforeValue != null)
                {
                    DateTime dtBeforeValue = Convert.ToDateTime(BeforeValue);

                    if (!dtBeforeValue.IsValidDateTime())
                    {
                        BeforeValue = DBNull.Value;
                    }
                }

                if (AfterValue != null)
                {
                    DateTime dtAfterValue = Convert.ToDateTime(AfterValue);

                    if (!dtAfterValue.IsValidDateTime())
                    {
                        AfterValue = DBNull.Value;
                    }
                }
            }
        }
    }
}