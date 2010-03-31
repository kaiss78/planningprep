using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Util;

namespace App.Domain
{
    public class FileCategoryManager
    {
        private DbDataContext _Data;

        public FileCategoryManager()
        {
            _Data = new DbDataContext(ConfigReader.ConnectionString);
        }
        public void Save(FileCategory category)
        {
            if (category.ID == 0)
            {
                _Data.FileCategories.InsertOnSubmit(category);
            }
            _Data.SubmitChanges();
        }

    }
}
