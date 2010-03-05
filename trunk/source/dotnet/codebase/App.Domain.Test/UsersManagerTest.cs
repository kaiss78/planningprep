using App.Domain.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Models.Users;
using System.Collections.Generic;

namespace App.Domain.Test
{
    
    
    /// <summary>
    ///This is a test class for UsersManagerTest and is intended
    ///to contain all UsersManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsersManagerTest
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
        public void SaveOrUpdateTest()
        {
            UsersManager target = new UsersManager(); // TODO: Initialize to an appropriate value
            User entity = null; // TODO: Initialize to an appropriate value
            target.SaveOrUpdate(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetList
        ///</summary>
        [TestMethod()]
        public void GetListTest()
        {
            UsersManager target = new UsersManager(); // TODO: Initialize to an appropriate value
            IEnumerable<User> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<User> actual;
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
            UsersManager target = new UsersManager(); // TODO: Initialize to an appropriate value
            long id = 0; // TODO: Initialize to an appropriate value
            bool eagerLoad = false; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
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
            UsersManager target = new UsersManager(); // TODO: Initialize to an appropriate value
            long id = 0; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
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
            UsersManager target = new UsersManager(); // TODO: Initialize to an appropriate value
            User entity = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UsersManager Constructor
        ///</summary>
        [TestMethod()]
        public void UsersManagerConstructorTest()
        {
            UsersManager target = new UsersManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
