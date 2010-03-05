


#region File Info/History
/*
 * =============================================
 * Project Name: [Project Name]
 * Assembly:	   [Assembly Name]
 * Name:		Product
 * Purpose: Product entity class 
 * Language: C# SDK version 3.5
 * Change History
 * =============================================
 * Jason Duffus	3/1/2010 11:45:14 AM		Initial Code
 * =============================================
 */
#endregion

using System;
using System.Collections;
using App.Core;
using App.Core.Base.Model;
using App.Core.Base.Managers;
using App.Core.Base.Managers.Responses;
using App.Models.Base;
using System.Transactions;
using App.Data.Products;
using App.Data;
using App.Models.Products;
using App.Core.Exceptions;
using System.Collections.Generic;
using Models.Products;

namespace App.Domain.Products
{
    public class ProductManager : ManagerBase<Product>,IProductManager
    {
        public ProductManager()
        { }

        #region CRUD Methods
        public override void SaveOrUpdate(Product entity)
        {
            using (new TimedTraceLog(GetType().Name + "SaveOrUpdate(Product)", ""))
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(60)))
                    {
                        using (IProductDAO dao = (IProductDAO)DAOFactory.Get<Product>())
                        {
                            dao.Save(entity);
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException<ManagerException>(ex, "ProductDAO.SaveOrUpdate(Product)");
                }
            }
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Product Get(long id)
        {
            Product Product = null;
            try
            {
                using (IProductDAO dao = (IProductDAO)DAOFactory.Get<Product>())
                {
                    Product = dao.Get(id, true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Product;
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="eagerLoad">if set to <c>true</c> [eager load].</param>
        /// <returns></returns>
        public override Product Get(long id, bool eagerLoad)
        {
            Product Product = null;
            try
            {
                using (IProductDAO dao = (IProductDAO)DAOFactory.Get<Product>())
                {
                    Product = dao.Get(id, eagerLoad);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return Product;
        }


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Product> GetList()
        {
            IEnumerable<Product> ProductList = new List<Product>();
            try
            {
                using (IProductDAO dao = (IProductDAO)DAOFactory.Get<Product>())
                {
                    ProductList = dao.GetAll(u => u.Active && !u.Deleted);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return ProductList;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductCategory> GetProductCategoryList()
        {
            IEnumerable<ProductCategory> CategoryList = new List<ProductCategory>();
            try
            {
                using (IProductCategoryDAO dao = (IProductCategoryDAO)DAOFactory.Get<ProductCategory>())
                {
                    CategoryList = dao.GetAll(u => u.Active && !u.Deleted);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return CategoryList;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override bool Delete(Product entity)
        {
            bool result = false;
            try
            {
                using (IProductDAO dao = (IProductDAO)DAOFactory.Get<Product>())
                {
                    result = dao.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException<ManagerException>(ex);
            }
            return result;
        }
        #endregion
    }
}
