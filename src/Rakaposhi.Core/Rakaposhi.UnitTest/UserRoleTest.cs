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
                                UserRoleID = 10,
                                UserRoleName = "Admin",
                                UserDescription = "AllRights"
                            },
                            new UserRole()
                            {
                                UserRoleID = 11,
                                UserRoleName = "Manager",
                                UserDescription = "SomeRights"
                            },
                            new UserRole()
                            {
                                UserRoleID = 11,
                                UserRoleName = "User",
                                UserDescription = "NoRights"
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
        [DataRow(1, "Maaz", "Admin")]
        [DataRow(2, "Taha", "Incharge")]
        [DataRow(3, "Hamza", "Manager")]
        [DataRow(4, "Arish", "Consultant")]
        [TestMethod]
        public void UserRoleCreate_Valid(long userId, string userName, string description)
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = userId,
                UserRoleName = userName,
                UserDescription = description
            };

            //Act
            var response = _controller.Create(userRole) as CreatedResult;
            var newUser = (UserRole)response.Value;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.Created == (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsNotNull(newUser);
            Assert.AreEqual(expected: userRole.UserRoleID, actual: newUser.UserRoleID);
            Assert.AreEqual(expected: userRole.UserRoleName, actual: newUser.UserRoleName);
            Assert.AreEqual(expected: userRole.UserDescription, actual: newUser.UserDescription);
        }


        [TestMethod]
        public void UserRoleCreate_InValid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = null,
                UserRoleName = "Maaz",
                UserDescription = "Consultant"
            };

            //Act
            var response = _controller.Create(userRole) as BadRequestObjectResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.BadRequest == (HttpStatusCode)response.StatusCode);
            Assert.IsTrue(condition: ErrorCode.ADDERROR == response.Value.ToString());
            Assert.AreEqual(expected: userRole.UserRoleID, actual: null);
        }

        
        [TestMethod]
        public void UserRoleUpdate_Valid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);

            var updateduserRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Not Admin",
                UserDescription = "He/She has all priviileges",
            };

            var response = _controller.Update(updateduserRole) as NoContentResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.NoContent == (HttpStatusCode)response.StatusCode);
            //Assert.IsTrue(condition: userRole.UserRoleName == updateduserRole.UserRoleName);
        }


        [TestMethod]
        public void UserRoleUpdate_InValid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);

            var updateduserRole = new UserRole()
            {
                UserRoleID = 11,
                UserRoleName = "Not Admin",
                UserDescription = "He/She has all priviileges",
            };

            var response = _controller.Update(updateduserRole) as BadRequestObjectResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.BadRequest == (HttpStatusCode)response.StatusCode);
            Assert.IsTrue(condition: ErrorCode.UPDATEERROR == response.Value.ToString());
            //Assert.IsFalse(condition: userRole.UserRoleName == updateduserRole.UserRoleName);
        }


        [TestMethod]
        public void UserRoleDelete_Valid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);
            var response = _controller.Delete(userRole.UserRoleID.Value) as NoContentResult;


            //Assert
            Assert.IsTrue(condition: HttpStatusCode.NoContent == (HttpStatusCode)response.StatusCode);
        }


        [TestMethod]
        public void UserRoleDelete_InValid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);
            userRole.UserRoleID = 11;
            var response = _controller.Delete(userRole.UserRoleID.Value) as BadRequestObjectResult;


            //Assert
            Assert.IsTrue(condition: HttpStatusCode.BadRequest == (HttpStatusCode)response.StatusCode);
            Assert.IsTrue(condition: ErrorCode.DELETEERROR == response.Value.ToString());
        }


        [TestMethod]
        public void UserRoleFind_Valid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);
            var actionResult = _controller.Find(userRole.UserRoleID.Value);


            //Assert
            var response = actionResult.Result as OkObjectResult;
            var getUser = (UserRole)response.Value;

            Assert.IsTrue(condition: HttpStatusCode.OK == (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(expected: userRole.UserRoleID, actual: getUser.UserRoleID);
            Assert.AreEqual(expected: userRole.UserRoleName, actual: getUser.UserRoleName);
            Assert.AreEqual(expected: userRole.UserDescription, actual: getUser.UserDescription);
        }


        [TestMethod]
        public void UserRoleFind_InValid()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            UserRoleCreate_Valid(userRole.UserRoleID.Value, userRole.UserRoleName, userRole.UserDescription);
            userRole.UserRoleID = 11;
            var actionResult = _controller.Find(userRole.UserRoleID.Value) ;


            //Assert
            var response = actionResult.Result as NotFoundResult;
            Assert.IsTrue(condition: HttpStatusCode.NotFound == (HttpStatusCode)response.StatusCode);
        }


        [TestMethod]
        [DynamicData(nameof(userRoles))]
        public void UserRoleGetAll_Valid(List<UserRole> userRoles)
        {
            //Arrange
            for(int i=0; i<userRoles.Count; i++)
            {
                UserRoleCreate_Valid(userRoles[i].UserRoleID.Value, userRoles[i].UserRoleName, userRoles[i].UserDescription);
            }

            //Act 
            var response = _controller.GetAll() as OkObjectResult;

            //Assert
            var allRoles = (IEnumerable<UserRole>)response.Value;
            Assert.IsNotNull(response);
            Assert.IsTrue(userRoles.Count == allRoles.Count());
        }
    }
}