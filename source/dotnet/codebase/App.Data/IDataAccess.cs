using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Principal;
using App.Core.Base.Model;

namespace App.Data
{
    public interface IDataAccess<T>: IDisposable
        where T : BaseEntity
    {
        void Save(T entity);
        void SaveAll(IList<T> entity);
        // void Save(T entity, DbTransaction transaction);

        bool Delete(T entity);
        bool DeleteAll(IList<T> entity);
        //bool Delete(T entity, DbTransaction transaction);

        T Get(long id);
        T Get(long id, bool eagerLoad);
        T Get(Func<T, bool> query);
        T Get(Func<T, bool> query, bool eagerLoad);

        List<T> GetAll(Func<T, bool> query);
        List<T> GetAll(bool eagerLoad);
        List<T> GetPagedList(Func<T, bool> query, int page, int pageSize);

        IPrincipal CurrentUser { get; set; }
    }
}


