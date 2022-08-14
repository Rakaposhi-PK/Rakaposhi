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
    public class RoleTest
    {
        private RoleController _controller;
        private static IEnumerable<object[]> roles
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<Role>()
                        {
                            new Role()
                            {
                                RecId = 1,
                                Name = "User1",
                                Description ="User1Description"
                            },
                            new Role()
                            {
                                RecId = 2,
                                Name = "User2",
                                Description = "User2Description"
                            },
                            new Role()
                            {
                                RecId = 3,
                                Name = "User3",
                                Description = "User3Description"
                            }
                        }
                    }
                };
            }
        }

        public RoleTest()
        {
            IRepositoryFactory factory = new FakeDBRepositoryFactory();
            RoleService roleService = new RoleService(factory);
            _controller = new RoleController(roleService);
        }


        [DataTestMethod]
        [DataRow(1, "User1", "User1Description")]
        [DataRow(1, "User2", "User2Description")]
        [DataRow(1, "User3", "User3Description")]

        [TestMethod]
        public void RoleCreate_Valid(long id, string name, string description)
        {
            //Arrange
            var role = new Role()
            {
                RecId = id,
                Name = name,
                Description = description
            };

            //Act
            var response = _controller.Create(role) as CreatedResult;
            var newRole = (Role)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(value: newRole);
            Assert.AreEqual(expected: role.RecId, actual: newRole.RecId);
            Assert.AreEqual(expected: role.Name, actual: newRole.Name);
            Assert.AreEqual(expected: role.Description, actual: newRole.Description);
        }

        [TestMethod]
        public void RoleCreate_InValid()
        {
            //Arrange
            var role = new Role()
            {
                RecId = null,
                Name = "User1"
            };

            //Act
            var response = _controller.Create(role) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.ADDERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Description")]
        [DataRow(1, "User2", "User2Description")]
        [TestMethod]
        public void RoleUpdate_Valid(long id, string name, string description)
        {
            //Arrange
            RoleCreate_Valid(id, name, description);

            //Act
            var updatedRole = new Role()
            {
                RecId = id,
                Name= "User2",
                Description= "FakeDescription"
            };

            var response = _controller.Update(updatedRole) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Description", 2)]
        [DataRow(1, "User2", "User2Description", 3)]
        [TestMethod]

        public void RoleUpdate_Invalid(long id, string name, string description, long updatedId)
        {
            //Arrange
            RoleCreate_Valid(id, name, description);

            //Act
            var updatedRole = new Role()
            {
                RecId = updatedId,
                Name = "User3",
                Description = "FakeUserDescription"
            };

            var response = _controller.Update(updatedRole) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Description")]
        [DataRow(1, "User2", "User2Description")]
        [TestMethod]

        public void RoleDelete_Valid(long id, string name, string description)
        {
            //Arrange
            RoleCreate_Valid(id, name, description);

            //Act
            var response = _controller.Delete(id) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Description")]
        [DataRow(1, "User2", "User2Description")]
        [TestMethod]

        public void RoleDelete_Invalid(long id, string name, string description)
        {
            //Arrange
            RoleCreate_Valid(id, name, description);

            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [TestMethod]
        public void RoleFind_Valid()
        {
            //Arrange
            var role = new Role()
            {
                RecId = 1,
                Name = "User1",
                Description = "User1Description"
            };

            RoleCreate_Valid(role.RecId.Value, role.Name, role.Description);

            //Act
            var actionResult = _controller.Find(role.RecId.Value);
            var response = actionResult.Result as OkObjectResult;
            var getRole = (Role)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(role.RecId, getRole.RecId.Value);
            Assert.AreEqual(role.Name, getRole.Name);
            Assert.AreEqual(role.Description, getRole.Description);
        }

        [TestMethod]
        public void RoleFind_InValid()
        {
            //Arrange
            var role = new Role()
            {
                RecId = 1,
                Name = "User1",
                Description = "User1Description"
            };

            //Act
            var actionResult = _controller.Find(role.RecId.Value);
            var response = actionResult.Result as NotFoundResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        }

        [TestMethod]
        [DynamicData(nameof(roles))]
        public void RoleGetAll_Valid(List<Role> roles)
        {
            //Arrange
            for (int i = 0; i < roles.Count; i++)
            {
                RoleCreate_Valid(roles[i].RecId.Value, roles[i].Name, roles[i].Description);
            }

            //Act
            var response = _controller.GetAll() as OkObjectResult;
            var allRoles = (IEnumerable<Role>)response.Value;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(roles.Count, allRoles.Count());
        }
    }
}