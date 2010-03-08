using System.Collections.Generic;
using App.Core.Base.Managers.Responses;
using App.Core.Base.Model;

namespace App.Core.Base.Managers
{
    public interface IManagerBase<T> where T : BaseEntity
    {
        void SaveOrUpdate(T entity);
        T Get(long id);
        T Get(long id, bool eagarLoad);

        IList<T> GetList();
        bool Delete(T entity);
    }
}


