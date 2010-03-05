using System.ComponentModel;
using App.Models.History;

namespace App.Models.Base
{
    public class PropertyAuditChangedEventArgs : PropertyChangedEventArgs
    {
        public PropertyAuditChangedEventArgs(string propertyName, HistoryData historyData)
            : base(propertyName)
        {
            HistoryData = historyData;
        }

        public HistoryData HistoryData { get; private set; }
    }
}