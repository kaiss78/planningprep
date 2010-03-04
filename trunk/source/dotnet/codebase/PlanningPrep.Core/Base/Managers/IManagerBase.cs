using System.Collections.Generic;
using PlanningPrep.Core.Base.Managers.Responses;
using PlanningPrep.Core.Base.Model;

namespace PlanningPrep.Core.Base.Managers
{
    public interface IManagerBase<T> where T : BaseEntity
    {
        void SaveOrUpdate(T entity);
        T Get(long id);
        T Get(long id, bool eagarLoad);

        IEnumerable<T> GetList();
        bool Delete(T entity);
    }
}


