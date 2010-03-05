using System.Collections.Generic;
using App.Models.History;
using App.Core.Base.Model;

namespace App.Data.History
{
    public interface IHistoryDataDAO : IDataAccess<HistoryData>
    {
        /// <summary>
        /// Gets the history for record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recordId">The record id.</param>
        /// <returns></returns>
        List<HistoryData> GetAllForRecord<T>(long recordId) where T : BaseEntity;
    }
}