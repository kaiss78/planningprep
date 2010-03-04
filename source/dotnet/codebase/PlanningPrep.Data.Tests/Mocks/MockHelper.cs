using System;
using PlanningPrep.Models.Users;
using PlanningPrep.Core.Factories;

namespace PlanningPrep.Data.Tests.Mocks
{
    public sealed class MockHelper
    {
        public static User CreateUnitTestUser(bool lockUser)
        {
            User testUser = EntityFactory.Create<User>();

            testUser.Id = -1;
            testUser.RoleId = new Random().Next(1, 4);
            testUser.FirstName = "Unit";
            testUser.LastName = "User - " + new Random().Next(1, 100);
            testUser.UserName = "UnitTest" + new Random().Next(1, 20);
            testUser.IMISUserId = new Random().Next(1, 5000).ToString();
            testUser.IMISMemberType = "Staff";
            testUser.Organization = "Pantheon";
            testUser.Email = "uninttest@test.com";
            testUser.Title = "Software Architect";
            testUser.Active = true;
            testUser.Deleted = false;
            testUser.Locked = lockUser;
            testUser.CreatedBy = "System.Agent";
            testUser.CreatedByDateTime = new DateTime();
            testUser.LastModifiedBy = "System.Agent";
            testUser.LastModifiedByDateTime = new DateTime();
            testUser.DatetimeStamp = new DateTime();

            return testUser;
        }

        //public static HttpContext FakeHttpContext()
        //{
            //var context = new Mock<HttpContext>();
            //var request = new Mock<HttpRequest>();
            //var response = new Mock<HttpResponse>();
            //var session = new Mock<HttpSessionState>();
            //var server = new Mock<HttpServerUtility>();
            //var user = new Mock<IPrincipal>();
            //var identity = new Mock<IIdentity>();

            //request.Expect(req => req.ApplicationPath).Returns("~/");
            //request.Expect(req => req.AppRelativeCurrentExecutionFilePath).Returns("~/");
            //request.Expect(req => req.PathInfo).Returns(string.Empty);
            //response.Expect(res => res.ApplyAppPathModifier(It.IsAny<string>()))
            //    .Returns((string virtualPath) => virtualPath);
            //user.Expect(usr => usr.Identity).Returns(identity.Object);
            //identity.ExpectGet(ident => ident.IsAuthenticated).Returns(true);

            //context.Expect(ctx => ctx.Request).Returns(request.Object);
            //context.Expect(ctx => ctx.Response).Returns(response.Object);
            //context.Expect(ctx => ctx.Session).Returns(session.Object);
            //context.Expect(ctx => ctx.Server).Returns(server.Object);
            //context.Expect(ctx => ctx.User).Returns(user.Object);

            //return context.Object;
        //}
    }
}
