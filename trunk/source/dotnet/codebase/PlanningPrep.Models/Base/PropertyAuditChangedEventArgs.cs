using System.ComponentModel;
using PlanningPrep.Models.History;

namespace PlanningPrep.Models.Base
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