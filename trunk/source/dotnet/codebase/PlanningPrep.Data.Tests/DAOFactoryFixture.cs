using PlanningPrep.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanningPrep.Data.History;
using PlanningPrep.Core.Base.Model;
using System.Security.Principal;

namespace PlanningPrep.Data.Tests
{
    
    
    /// <summary>
    ///This is a test class for DAOFactoryFixture and is intended
    ///to contain all DAOFactoryFixture Unit Tests
    ///</summary>
    [TestClass]
    public class DAOFactoryFixture : BaseTestClass
    {
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
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

        [TestMethod]
        [Owner("Jason Duffus")]
        public void Get_Specified_DAO_From_DAOFactory_Test()
        {
            IDataAccess<Models.History.HistoryData> expected = new HistoryDataDAO(); 
            IDataAccess<Models.History.HistoryData> actual = DAOFactory.Get<Models.History.HistoryData>();
            Assert.IsNotNull(actual, "Specified DAO was not found. Make sure it is added to the DataAccessObject.xml embeded config file.");
            Assert.AreEqual(expected.GetType(), actual.GetType(), "DAOs do not match. Please make sure that the expected type matches the actual dao.");
        }
    }
}
