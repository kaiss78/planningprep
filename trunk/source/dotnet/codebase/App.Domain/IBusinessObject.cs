using System.Collections.Generic;
using App.Core.Base;
using App.Core.Base.Model;

namespace App.BLL
{
    public interface IBusinessObject<T> where T : BaseEntity
    {
        void Save();
        T Get(long ID);
        List<T> GetList();
        bool Delete(long ID);
    }
}
