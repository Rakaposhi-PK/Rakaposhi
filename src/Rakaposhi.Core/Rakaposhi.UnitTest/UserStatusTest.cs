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
        private static IEnumerable<object[]> userStatuses
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<UserStatus>()
                        {
                            new UserStatus()
                            {
                                RecId = 1,
                                Status = "Created"
                            },
                            new UserStatus()
                            {
                                RecId = 2,
                                Status = "Approved"
                            },
                            new UserStatus()
                            {
                                RecId = 3,
                                Status = "Not Approved"
                            }
                        }
                    }
                };
            }
        }
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

        [DataTestMethod]
        [DataRow(1, "Created")]
        [DataRow(2, "Approved")]
        public void UserStatusUpdate_Valid(long id, string status)
        {
            //Arrange
            UserStatusCreate_Valid(id, status);

            //Act
            var updatedUserStatus = new UserStatus()
            {
                RecId = id,
                Status = "Not Approved"
            };

            var response = _controller.Update(updatedUserStatus) as NoContentResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.NoContent == (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "Created", 2)]
        [DataRow(1, "Approved", 3)]

        public void UserStatusUpdate_Invalid(long id, string status, long updatedId)
        {
            //Arrange
            UserStatusCreate_Valid(id, status);

            //Act
            var updateUserStatus = new UserStatus()
            {
                RecId = updatedId,
                Status = "Not Approved"
            };

            var response = _controller.Update(updateUserStatus) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "Created")]
        [DataRow(2, "Approved")]
        public void UserStatusDelete_Valid(long id, string status)
        {
            //Arrange
            UserStatusCreate_Valid(id, status);

            //Act
            var response = _controller.Delete(id) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "Created")]
        [DataRow(2, "Approved")]
        public void UserStatusDelete_Invalid(long id, string status)
        {
            //Arrange
            UserStatusCreate_Valid(id, status);

            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [TestMethod]
        public void UserStatusFind_Valid()
        {
            //Arrange
            var userStatus = new UserStatus()
            {
                RecId = 1,
                Status = "Created"
            };

            UserStatusCreate_Valid(userStatus.RecId.Value, userStatus.Status);

            //Act
            var actionResult = _controller.Find(userStatus.RecId.Value) ;
            var response = actionResult.Result as OkObjectResult;
            var getuserStatus = (UserStatus)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(userStatus.RecId, getuserStatus.RecId.Value);
            Assert.AreEqual(userStatus.Status, getuserStatus.Status);
        }

        [TestMethod]
        public void UserStatusFind_InValid()
        {
            //Arrange
            var userStatus = new UserStatus()
            {
                RecId = 1,
                Status = "Created"
            };

            //Act
            var actionResult = _controller.Find(userStatus.RecId.Value);
            var response = actionResult.Result as NotFoundResult ;
           
            //Assert
            Assert.AreEqual( HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        }

        [TestMethod]
        [DynamicData(nameof(userStatuses))]
        public void UserStatusGetAll_Valid(List<UserStatus> userStatuses)
        {
            //Arrange
            for(int i=0; i<userStatuses.Count; i++)
            {
                UserStatusCreate_Valid(userStatuses[i].RecId.Value, userStatuses[i].Status);
            }

            //Act
            var response = _controller.GetAll() as OkObjectResult;
            var allStatuses = (IEnumerable<UserStatus>)response.Value;
            //Assert
            
            Assert.IsNotNull(response);
            Assert.AreEqual( userStatuses.Count, allStatuses.Count());
        }
    }
}
