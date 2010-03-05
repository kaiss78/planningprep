using System;
using System.Collections.Generic;
using System.ComponentModel;
using App.Models.Enums;
using App.Models.History;

namespace App.Models.Base
{
    /// <summary>
    /// Base class for Entity
    /// </summary>
    [Serializable]
    public abstract class HistoryEntity : TableLevelAuditEntity, INotifyPropertyChanged
    {
        #region Properties
        public List<HistoryData> HistoryDataList { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public override void CleanBeforeSave()
        {}

        public void NotifyPropertyChanged(HistoryType historyType, string fieldName, PantheonDbType sqlFieldTypeCode, object beforeValue, object afterValue, long recordId, string userName, long projectId)
        {
            NotifyPropertyChanged(historyType, fieldName, sqlFieldTypeCode, beforeValue, afterValue, recordId, userName, projectId, string.Empty);
        }

        public void NotifyPropertyChanged(HistoryType historyType, string fieldName, PantheonDbType sqlFieldTypeCode, object beforeValue, object afterValue, long recordId, string userName, long projectId, string reasonForChange)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            HistoryData historyData = HistoryData.CreateNewWithModifiedData(historyType, fieldName, sqlFieldTypeCode, beforeValue, afterValue, recordId, projectId, reasonForChange);
            PropertyChanged(this, new PropertyAuditChangedEventArgs(fieldName, historyData));
        }
        #endregion
    }
}