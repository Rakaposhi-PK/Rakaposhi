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
    public class UserRoleTest
    {
        private UserRoleController _controller;

        private static IEnumerable<object[]> userRoles
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<UserRole>()
                        {
                            new UserRole()
                            {
                                RecId =12,
                                UserId = 10,
                                RoleId = 1,
                            },
                            new UserRole()
                            {
                                RecId = 11,
                                UserId = 1,
                                RoleId = 2,
                            },
                            new UserRole()
                            {
                                RecId = 1,
                                UserId = 10,
                                RoleId = 1,
                            }
                        }
                    }
                };
            }
        }

        public UserRoleTest()
        {
            IRepositoryFactory factory = new FakeDBRepositoryFactory();
            UserRoleService userRoleService = new UserRoleService(factory);
            _controller = new UserRoleController(userRoleService);
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 3)]
        [DataRow(3, 2, 4)]
        [TestMethod]
        public void UserRoleCreate_Valid(long recId, long userId, long roleId)
        {
            //Arrange
            var userRole = new UserRole()
            {
                RecId = recId,
                UserId = userId,
                RoleId = roleId
            };

            //Act
            var response = _controller.Create(userRole).Result as CreatedResult;
            var newUser = (UserRole)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsNotNull(newUser);
            Assert.AreEqual(expected: userRole.UserId, actual: newUser.UserId);
            Assert.AreEqual(expected: userRole.RoleId, actual: newUser.RoleId);
        }

        [TestMethod]
        public void UserRoleCreate_InValid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                RecId = null,
                UserId = 1,
                RoleId = 2
            };

            //Act
            var response = _controller.Create(userRole).Result as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.ADDERROR, response.Value.ToString());
            Assert.AreEqual(expected: userRole.RecId, actual: null);
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 3)]
        [DataRow(3, 2, 4)]
        [TestMethod]
        public void UserRoleUpdate_Valid(long recId, long userId, long roleId)
        {
            //Arrange
            UserRoleCreate_Valid(recId, userId, roleId);

            //Act
            var updateduserRole = new UserRole()
            {
                RecId = recId,
                UserId = 1,
                RoleId = 2
            };

            var response = _controller.Update(updateduserRole) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 2, 3, 2)]
        [DataRow(1, 2, 3, 2)]
        [TestMethod]
        public void UserRoleUpdate_InValid(long recId, long userId, long roleId, long updatedId)
        {
            //Arrange
            UserRoleCreate_Valid(recId, userId, roleId);

            //Act
            var updateduserRole = new UserRole()
            {
                RecId = updatedId,
                UserId = userId,
                RoleId = roleId
            };

            var response = _controller.Update(updateduserRole) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 3)]
        [TestMethod]
        public void UserRoleDelete_Valid(long recId, long userId, long roleId)
        {
            //Arrange
            UserRoleCreate_Valid(recId, userId, roleId);

            //Act
            var response = _controller.Delete(recId) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 2, 3)]
        [TestMethod]
        public void UserRoleDelete_InValid(long recId, long userId, long roleId)
        {
            //Arrange
            UserRoleCreate_Valid(recId, userId, roleId);
            
            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [TestMethod]
        public void UserRoleFind_Valid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                RecId = 1,
                UserId = 2,
                RoleId = 1
            };

            UserRoleCreate_Valid(userRole.RecId.Value, userRole.UserId, userRole.RoleId);

            //Act
            var actionResult = _controller.Find(userRole.RecId.Value);
            var response = actionResult.Result as OkObjectResult;
            var getUser = (UserRole)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(expected: userRole.RecId, actual: getUser.RecId);
            Assert.AreEqual(expected: userRole.UserId, actual: getUser.UserId);
            Assert.AreEqual(expected: userRole.RoleId, actual: getUser.RoleId);
        }

        //[TestMethod]
        //public void UserRoleFind_InValid()
        //{
        //    //Arrange
        //    var userRole = new UserRole()
        //    {
        //        RecId = 1,
        //        UserId = 2,
        //        RoleId = 1
        //    };

        //    //Act
        //    var actionResult = _controller.Find(userRole.RecId.Value);
        //    var response = actionResult.Result as NotFoundResult;

        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        //}

        [TestMethod]
        [DynamicData(nameof(userRoles))]
        public void UserRoleGetAll_Valid(List<UserRole> userRoles)
        {
            //Arrange
            for(int i = 0; i < userRoles.Count; i++)
            {
                UserRoleCreate_Valid(userRoles[i].RecId.Value, userRoles[i].UserId, userRoles[i].RoleId);
            }

            //Act 
            var response = _controller.GetAll().Result as OkObjectResult;
            var allRoles = (IEnumerable<UserRole>)response.Value;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(userRoles.Count, allRoles.Count());
        }
    }
}