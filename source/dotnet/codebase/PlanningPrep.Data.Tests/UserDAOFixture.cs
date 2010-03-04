using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanningPrep.Data.Tests.Mocks;
using PlanningPrep.Data.Users;
using PlanningPrep.Models.Users;
using System.Globalization;

namespace PlanningPrep.Data.Tests
{
    /// <summary>
    /// Summary description for UserDAOFixture
    /// </summary>
    [TestClass]
    public class UserDAOFixture : BaseTestClass
    {
        #region Additional test attributes
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [Owner("Jason Duffus")]
        public void UserDAOFixture_Get_User_By_Id()
        {
            User userToCheck;
            using(IUserDAO dao = (IUserDAO) DAOFactory.Get<User>())
            {
                userToCheck = dao.Get(1);
            }

            Assert.IsNotNull(userToCheck, "The user is null.");
            Assert.IsTrue(userToCheck.RoleId == 1);
            Assert.IsTrue(userToCheck.UserName.ToLower(CultureInfo.InvariantCulture) == "jduffus");
        }

        [TestMethod]
        [Owner("Jason Duffus")]
        public void UserDAOFixture_Get_All_Users()
        {
            List<User> usersList;
            using (IUserDAO dao = (IUserDAO)DAOFactory.Get<User>())
            {
                usersList = dao.GetAll(false);
            }

            Assert.IsNotNull(usersList, "The user list is null.");
            Assert.IsTrue(usersList.Count > 0);

            usersList.ForEach(u => Assert.IsTrue(u.IMISMemberType.ToLowerInvariant() == "staff" || u.IMISMemberType.ToLowerInvariant() == "admin"));
        }

        [TestMethod]
        [Owner("Jason Duffus")]
        public void UserDAOFixture_Get_All_Users_By_Linq_Expression()
        {
            string imisMemberType = "Staff";
            List<User> usersList;
            using (IUserDAO dao = (IUserDAO)DAOFactory.Get<User>())
            {
                usersList = dao.GetAll(u => u.IMISMemberType.ToLowerInvariant() == imisMemberType.ToLowerInvariant());
            }

            Assert.IsNotNull(usersList, "The user list is null.");
            Assert.IsTrue(usersList.Count > 0);

            usersList.ForEach(u => Assert.IsTrue(u.IMISMemberType.ToLowerInvariant() == imisMemberType.ToLowerInvariant()));
        }


        [TestMethod]
        [Owner("Jason Duffus")]
        public void UserDAOFixture_Save_User_With_TransactionScope()
        {
            User testUser = MockHelper.CreateUnitTestUser(false);

            Assert.IsTrue(testUser.IsNew);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromSeconds(30)))
            {
                using (IUserDAO dao = (IUserDAO) DAOFactory.Get<User>())
                {
                    dao.Save(testUser);

                    Assert.IsNotNull(testUser, "The user is null.");
                    Assert.IsFalse(testUser.IsNew);
                    Assert.IsTrue(testUser.UserName.ToLower(CultureInfo.InvariantCulture).Contains("test"));

                    long userId = testUser.Id;
                    DateTime dtStamp = testUser.DatetimeStamp;

                    //Modifiy UserName Value
                    testUser.UserName = "jduffus";

                    dao.Save(testUser);

                    Assert.IsNotNull(testUser, "The user is null after the update.");
                    Assert.IsFalse(testUser.IsNew);
                    Assert.IsTrue(dtStamp < testUser.DatetimeStamp);
                    Assert.IsTrue(testUser.UserName.ToLower(CultureInfo.InvariantCulture).Equals("jduffus"));

                    Assert.IsTrue(dao.Delete(testUser));
                    
                    User user2 = dao.GetAll(u => u.Id == userId).SingleOrDefault();

                    Assert.IsNull(user2);
                    
                    scope.Complete();
                }
            }
        }
    }
}
