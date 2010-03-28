using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Util;

namespace App.Domain
{
    public class ChapterFileManager
    {
        private DbDataContext db = null;
        public ChapterFileManager()
        {
            db = new DbDataContext(ConfigReader.ConnectionString);
        }
        public static ChapterFileManager Instance
        {
            get
            {
                return new ChapterFileManager();
            }
        }

        public ChapterDefinitionFile GetById(int id)
        {
            try
            {
                return db.ChapterDefinitionFiles.Single(c => c.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public ChapterDefinitionFile GetByFileName(string fileName)
        {
            try
            {
                return db.ChapterDefinitionFiles.Single(c => c.FileName.ToLower() == fileName.ToLower());
            }
            catch
            {
                return null;
            }
        }

        public List<ChapterDefinitionFile> GetAll()
        {
            var files = db.ChapterDefinitionFiles.Where(c => c.Id > 0);
            return files.ToList();
        }

        public int Save(ChapterDefinitionFile file)
        {
            if (file != null)
            {
                if (file.Id == 0)
                {
                    file.CreationTime = DateTime.Now;
                    file.ModificationTime = DateTime.Now;
                    db.ChapterDefinitionFiles.InsertOnSubmit(file);
                    db.SubmitChanges();
                }
                else
                {
                    var chapterDefinitionFile = db.ChapterDefinitionFiles.Single(c => c.Id == file.Id);
                    chapterDefinitionFile.ModificationTime = DateTime.Now;
                    db.SubmitChanges();
                }
                
                return file.Id;
            }
            return 0;
        }

        public void Update(ChapterDefinitionFile file)
        {
            
        }
    }
}
