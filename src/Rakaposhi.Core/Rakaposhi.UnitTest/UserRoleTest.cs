using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakaposhi.API.Core.Controllers;
using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.FakeRepository;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.UnitTest
{
    [TestClass]
    public class UserRoleTest
    {
        UserRoleController controller;
        UserRole userRole;

        public UserRoleTest()
        {
            userRole = new UserRole()
            {
                UserRoleID = 10,
                UserRoleName = "Admin",
                UserDescription = "He/She has all priviileges"
            };

            IRepositoryFactory factory = new FakeDBRepositoryFactory();

            UserRoleService userRoleService = new UserRoleService(factory);

            controller = new UserRoleController(userRoleService);
        }


        [TestMethod]
        public void UserRoleCreate()
        {
            //Act
            var respones = controller.Create(userRole);

            //Assert Not Working
            Assert.AreEqual(typeof(Microsoft.AspNetCore.Mvc.CreatedResult), respones);
        }
    }
}