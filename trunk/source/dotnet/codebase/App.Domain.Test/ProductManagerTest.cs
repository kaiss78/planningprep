using App.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Models.Products;
using System.Collections.Generic;

namespace App.Domain.Test
{
    
    
    /// <summary>
    ///This is a test class for ProductManagerTest and is intended
    ///to contain all ProductManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SaveOrUpdate
        ///</summary>
        [TestMethod()]
        public void ProductManagerTest_SaveOrUpdateTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value

            Product entity = target.Get(1);
            entity.Price = 200;
            entity.ProductCategoryId = 1;
            entity.ProductName = "Test Product2";

            target.SaveOrUpdate(entity);
            target.Delete(entity);
            Assert.AreNotSame(0, entity.Id);
        }

        /// <summary>
        ///A test for GetList
        ///</summary>
        [TestMethod()]
        public void GetListTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            IEnumerable<Product> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Product> actual;
            actual = target.GetList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        public void GetTest1()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            long id = 0; // TODO: Initialize to an appropriate value
            bool eagerLoad = false; // TODO: Initialize to an appropriate value
            Product expected = null; // TODO: Initialize to an appropriate value
            Product actual;
            actual = target.Get(id, eagerLoad);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            long id = 0; // TODO: Initialize to an appropriate value
            Product expected = null; // TODO: Initialize to an appropriate value
            Product actual;
            actual = target.Get(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Product entity = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProductManager Constructor
        ///</summary>
        [TestMethod()]
        public void ProductManagerConstructorTest()
        {
            ProductManager target = new ProductManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
