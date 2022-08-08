using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakaposhi.API.Core.Controllers;
using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.FakeRepository;
using Rakaposhi.Business.Core.Services;
using System.Net;

namespace Rakaposhi.UnitTest
{
    [TestClass]
    public class UserStatusTest
    {
        private UserStatusController _controller;

        public UserStatusTest()
        {
            IRepositoryFactory factory = new FakeDBRepositoryFactory();
            UserStatusService userStatusService = new UserStatusService(factory);
            _controller = new UserStatusController(userStatusService);

        }
        [DataTestMethod]
        [DataRow(1, "Created")]
        [DataRow(2, "Approved")]
        [DataRow(3, "Not Approved")]

        [TestMethod]
        public void UserStatusCreate_Valid(long id, string status)
        {
            //Arrange
            var userStatus = new UserStatus()
            {
                RecId = id,
                Status = status
            };

            //Act
            var response = _controller.Create(userStatus) as CreatedResult;
            var newUserStatus = (UserStatus)response.Value;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.Created == (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(value: newUserStatus);
            Assert.AreEqual(expected: userStatus.RecId, actual: newUserStatus.RecId);
            Assert.AreEqual(expected: userStatus.Status, actual: newUserStatus.Status);
        }

        [TestMethod]
        public void UserStatusCreate_InValid()
        {
            //Arrange
            var userStatus = new UserStatus()
            {
                RecId = null,
                Status = "Created"
            };

            //Act
            var response = _controller.Create(userStatus) as BadRequestObjectResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.BadRequest == (HttpStatusCode)response.StatusCode);
            Assert.IsTrue(condition: ErrorCode.ADDERROR == response.Value.ToString());
            Assert.AreEqual(expected: userStatus.RecId, actual: null);
        }
    }
}
