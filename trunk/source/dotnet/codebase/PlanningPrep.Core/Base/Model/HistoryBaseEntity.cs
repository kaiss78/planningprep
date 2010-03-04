#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.Common
 * Name: BaseEntity.cs
 * Purpose: Base Entity class
 *                   
 * Author: AFS
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    AFS  09/26/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion

#region References

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pantheon.Core.Base.Model;

#endregion

namespace Pantheon.Core.Base
{
    /// <summary>
    /// Base class for Entity
    /// </summary>
    [Serializable]
    public abstract class HistoryBaseEntity : BaseEntity, INotifyPropertyChanged
    {
        #region Properties
        public List<HistoryData> HistoryDataList { get; set; }
        public bool IsNew { get{ return (ID <= 0);} }

        public static bool IsLoading { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public virtual void CleanBeforeSave()
        {}
        

        public void NotifyPropertyChanged(byte dataTypeCode, string dataTypeName, string fieldName, byte sqlFieldTypeCode, object beforeValue, object afterValue, long dataId, string dataName, string userName, long projectId)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            NotifyPropertyChanged(dataTypeCode, dataTypeName, fieldName, sqlFieldTypeCode, beforeValue, afterValue, dataId, dataName, userName, projectId, string.Empty);
        }

        public void NotifyPropertyChanged(byte dataTypeCode, string dataTypeName, string fieldName, byte sqlFieldTypeCode, object beforeValue, object afterValue, long dataId, string dataName, string userName, long projectId, string reasonForChange)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            HistoryData historyData = HistoryData.CreateNewWithModifiedData(dataTypeCode, dataTypeName, fieldName, sqlFieldTypeCode, beforeValue, afterValue, dataId, dataName, userName, projectId, reasonForChange);
            PropertyChanged(this, new OPLMPropertyChangedEventArgs(fieldName, historyData));
        }
        #endregion
    }

    public class OPLMPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        public OPLMPropertyChangedEventArgs(string propertyName, HistoryData historyData)
            : base(propertyName)
        {
            HistoryData = historyData;
        }

        public HistoryData HistoryData { get; private set; }
    }
}