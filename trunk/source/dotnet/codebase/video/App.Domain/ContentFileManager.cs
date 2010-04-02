using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Util;

namespace App.Domain
{
    public class ContentFileManager
    {
        private DbDataContext _Data;

        public ContentFileManager()
        {
            _Data = new DbDataContext(ConfigReader.ConnectionString);
        }
        public List<ContentFile> GetAll()
        {
            return _Data.ContentFiles.ToList();
        }
        /// <summary>
        /// Gets a File Content Object By File ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContentFile GetByID(long FileID)
        {
            return _Data.ContentFiles.SingleOrDefault(F => F.FileID == FileID);
        }
        /// <summary>
        /// Gets a File Content Object By FileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ContentFile GetByFileName(String fileName)
        {
            return _Data.ContentFiles.SingleOrDefault(F => String.Compare(F.FileName, fileName, true) == 0);
        }
        /// <summary>
        /// Saves a FileContent object to the Database.
        /// </summary>
        /// <param name="file"></param>
        public void Save(ContentFile file)
        {
            if (file.FileID == 0)
            {
                file.UploadedOn = DateTime.Now;
                file.Modified = DateTime.Now;
                _Data.ContentFiles.InsertOnSubmit(file);
            }
            else
                file.Modified = DateTime.Now;

            _Data.SubmitChanges();
        }
        /// <summary>
        /// Delets a File Content from Database
        /// </summary>
        /// <param name="file"></param>
        public void Delete(ContentFile file)
        {
            var filesToDelete =
                from f in _Data.ContentFiles
                where f.FileName == file.FileName
                select f;
            
            if (filesToDelete != null && filesToDelete.Count() > 0)
            {
                _Data.ContentFiles.DeleteAllOnSubmit(filesToDelete);
                _Data.SubmitChanges();
                file = null;
            }
        }
    }
}
