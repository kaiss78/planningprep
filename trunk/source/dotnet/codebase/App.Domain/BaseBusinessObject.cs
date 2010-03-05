using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pantheon.Entity;
using App.Models.Users;
using App.Core.Base;
using App.Core.Base.Model;

namespace App.BLL
{
    public abstract class BaseBusinessObject<T> : IBusinessObject<T> where T : BaseEntity
    {
        protected BaseBusinessObject()
        {
        }

        protected BaseBusinessObject(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }

        public AppUser LoggedInUser { get; set; }

        public abstract void Save();

        public abstract T Get(long id);

        public abstract List<T> GetList();

        public abstract bool Delete(long id);
    }
}
