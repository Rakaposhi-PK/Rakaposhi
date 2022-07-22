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
        //[DynamicData(nameof(AddUsers))]
        public void UserRoleCreate(long userId, string userName, string description)
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
            Assert.AreEqual(expected: userRole.UserRoleID, actual: newUser.UserRoleID);
            Assert.AreEqual(userRole.UserRoleName, newUser.UserRoleName);
            Assert.AreEqual(userRole.UserDescription, newUser.UserDescription);
        }

        [TestMethod]
        public void UserRoleUpdate()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            _controller.Create(userRole);

            var updateduserRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Not Admin",
                UserDescription = "He/She has all priviileges",
            };

            var response = _controller.Update(updateduserRole) as NoContentResult;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.NoContent == (HttpStatusCode)response.StatusCode);        
        }

        [TestMethod]
        public void UserRoleGetAll()
        {
            //Arrange
            var userRole = new UserRole()
            {
                UserRoleID = 11,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges",
            };

            //Act
            //var response = controller.GetAll() as ViewResult;


            //Assert
            //Assert.AreEqual(HttpStatusCode., response.StatusCode);
        }
    }
}