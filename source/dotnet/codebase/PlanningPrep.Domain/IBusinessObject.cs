using System.Collections.Generic;
using PlanningPrep.Core.Base;
using PlanningPrep.Core.Base.Model;

namespace PlanningPrep.BLL
{
    public interface IBusinessObject<T> where T : BaseEntity
    {
        void Save();
        T Get(long ID);
        List<T> GetList();
        bool Delete(long ID);
    }
}
