using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Util;

namespace App.Domain
{
    public class FileTrackingManager
    {
        private DbDataContext _Data;

        public FileTrackingManager()
        {
            _Data = new DbDataContext(ConfigReader.ConnectionString);
        }
        /// <summary>
        /// Gets the View Count of a File
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public int GetViewCount(long fileId)
        {
            return (from P in _Data.FileTrackings
                    where P.FileID == fileId && P.IsViewed == true
                    select P).Count();
        }
        /// <summary>
        /// Gets the Download Count of a File
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public int GetDownloadCount(long fileId)
        {
            return (from P in _Data.FileTrackings
                    where P.FileID == fileId && P.IsDownloaded == true
                    select P).Count();
        }
        /// <summary>
        /// Saves a File Tracking Object into the Database
        /// </summary>
        /// <param name="tracking"></param>
        public void Save(FileTracking tracking)
        {
            if (tracking.ID == 0)
            {
                tracking.Created = DateTime.Now;
                _Data.FileTrackings.InsertOnSubmit(tracking);
            }
            _Data.SubmitChanges();
        }
    }
}
