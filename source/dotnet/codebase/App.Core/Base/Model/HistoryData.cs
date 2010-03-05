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
using Pantheon.Core.DB;
using System.Data;
using Pantheon.Core.Factories;

#endregion

#region Class

namespace Pantheon.Core.Base.Model
{
    [Serializable]
    public class HistoryData : BaseEntity
    {
        #region Instance creation

        /// <summary>
        /// Creates the new Entity object.
        /// </summary>
        /// <returns></returns>
        public static HistoryData CreateNew()
        {
            return new HistoryData();
        }

        /// <summary>
        /// Creates the new Entity object with modified data.
        /// </summary>
        /// <returns></returns>
        public static HistoryData CreateNewWithModifiedData(byte dataTypeCode, string dataTypeName, string fieldName, byte sqlFieldTypeCode, object beforeValue,object afterValue,long dataId, string dataName,string userName,long projectId,string reasonForChange)
        {
            HistoryData historyData = EntityFactory.Create<HistoryData>(); 

            historyData.DataTypeCode = dataTypeCode;
            historyData.DataTypeName = dataTypeName;
            historyData.FieldName = fieldName;
            historyData.SQLFieldTypeCode = sqlFieldTypeCode;
            historyData.BeforeValue = beforeValue;
            historyData.AfterValue = afterValue;
            historyData.DataID = dataId;
            historyData.DataName = dataName;
            historyData.UserName = userName;
            historyData.ProjectID = projectId;
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
            HistoryData historyData = CreateNew();
            historyData.ID = NullHandler.GetLong(reader["HistoryID"]);
            historyData.ProjectID = NullHandler.GetLong(reader["ProjectID"]);
            historyData.DataTypeName = NullHandler.GetString(reader["DataTypeName"]);
            historyData.DataTypeCode = NullHandler.GetByte(reader["DataTypeCode"]);
            historyData.FieldName = NullHandler.GetString(reader["FieldName"]);
            historyData.ReasonForChange = NullHandler.GetString(reader["ReasonForChange"]);
            historyData.SQLFieldTypeCode = NullHandler.GetByte(reader["SQLFieldTypeCode"]);
            historyData.BeforeValue = reader["BeforeValue"];
            historyData.AfterValue = reader["AfterValue"];
            historyData.UserID = NullHandler.GetLong(reader["UserID"]);
            historyData.UserName = NullHandler.GetString(reader["UserName"]);
            historyData.UserFirstName = NullHandler.GetString(reader["UserFirstName"]);
            historyData.UserLastName = NullHandler.GetString(reader["UserLastName"]);
            historyData.DataID = NullHandler.GetLong(reader["DataID"]);
            historyData.DataName = NullHandler.GetString(reader["DataName"]);
            historyData.DateTimeStamp = NullHandler.GetDateTime(reader["DTS"]);
            // historyData.PreviousDTS = NullHandler.GetDateTime(reader["PreviousDTS"]);
            return historyData;
        }

        #endregion

        #region Properties

        private long _historyID;
        private long _projectID;
        private string _dataTypeName;
        private byte _dataTypeCode;
        private string _fieldName;
        private byte _sQLFieldTypeCode;
        private object _beforeValue;
        private object _afterValue;
        private DateTime _dTS;
        private DateTime _previousDTS;

        /// <summary>
        /// Gets or sets the ProjectID
        /// </summary>
        public long ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }
        /// <summary>
        /// Gets or sets the DataTypeName
        /// </summary>
        public string DataTypeName
        {
            get { return _dataTypeName; }
            set { _dataTypeName = value; }
        }
        /// <summary>
        /// Gets or sets the DataTypeCode
        /// </summary>
        public byte DataTypeCode
        {
            get { return _dataTypeCode; }
            set { _dataTypeCode = value; }
        }
        /// <summary>
        /// Gets or sets the FieldName
        /// </summary>
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }
        /// <summary>
        /// Gets or sets the SQLFieldTypeCode
        /// </summary>
        public byte SQLFieldTypeCode
        {
            get { return _sQLFieldTypeCode; }
            set { _sQLFieldTypeCode = value; }
        }
        /// <summary>
        /// Gets or sets the BeforeValue
        /// </summary>
        public object BeforeValue
        {
            get { return _beforeValue; }
            set { _beforeValue = value; }
        }
        /// <summary>
        /// Gets or sets the AfterValue
        /// </summary>
        public object AfterValue
        {
            get { return _afterValue; }
            set { _afterValue = value; }
        }

        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the UserFirstName
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// Gets or sets the UserLastName
        /// </summary>
        public string UserLastName { get; set; }

        /// <summary>
        /// Gets or sets the DataID
        /// </summary>
        public long DataID { get; set; }

        /// <summary>
        /// Gets or sets the DataName
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// Gets or sets the ReasonForChange
        /// </summary>
        public string ReasonForChange { get; set; }

        #endregion

        public override void CleanBeforeSave()
        {
            base.CleanBeforeSave();

            if (SQLFieldTypeCode == OPUSConstants.DBTypes.DbTypeDateTime)
            {
                if (BeforeValue != null)
                {
                    DateTime dtBeforeValue = Convert.ToDateTime(BeforeValue);

                    if (dtBeforeValue == DateTime.MinValue)
                    {
                        BeforeValue = DBNull.Value;
                    }
                }

                if (AfterValue != null)
                {
                    DateTime dtAfterValue = Convert.ToDateTime(AfterValue);

                    if (dtAfterValue == DateTime.MinValue)
                    {
                        AfterValue = DBNull.Value;
                    }
                }
            }
        }
    }
}

#endregion