using System.Collections.Generic;
using System.Security.Principal;
using PlanningPrep.Core.Base.Managers.Responses;
using PlanningPrep.Core.Base.Model;

namespace PlanningPrep.Core.Base.Managers
{
    public abstract class ManagerBase<T> : DisposableBase, IManagerBase<T>
        where T : BaseEntity
    {
        public abstract void SaveOrUpdate(T entity);
        public abstract T Get(long id);
        public abstract T Get(long id, bool eagarLoad);
        public abstract IEnumerable<T> GetList();
        public abstract bool Delete(T entity);

        public IPrincipal CurrentUser { get; set; }

        #region Helper Methods
        //public T ProcessResponse<T>(T response)
        //    where T : PanthResponse
        //{
        //    response.Result = (string.IsNullOrEmpty(response.Exception) && response.Errors.Count == 0 );
        //    return response;
        //}
        #endregion
    }
}