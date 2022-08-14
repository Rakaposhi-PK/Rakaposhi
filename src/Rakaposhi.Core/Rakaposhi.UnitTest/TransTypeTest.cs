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
    public class TransTypeTest
    {
        private TransTypeController _controller;
        private static IEnumerable<object[]> transTypes
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<TransType>()
                        {
                            new TransType()
                            {
                                RecId = 1,
                                Name = "User1",
                                Description ="User1Transactiontype"
                            },
                            new TransType()
                            {
                                RecId = 2,
                                Name = "User2",
                                Description = "User2Transactiontype"
                            },
                            new TransType()
                            {
                                RecId = 3,
                                Name = "User3",
                                Description = "User3Transactiontype"
                            }
                        }
                    }
                };
            }
        }

        public TransTypeTest(TransTypeController controller)
        {
            IRepositoryFactory factory = new FakeDBRepositoryFactory();
            TransTypeService transTypeService = new TransTypeService(factory);
            _controller = new TransTypeController(transTypeService);
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Transactiontype")]
        [DataRow(2, "User2", "User2Transactiontype")]
        [DataRow(3, "User3", "User3Transactiontype")]
  
        [TestMethod]
        public void TransTypeCreate_Valid(long id, string name, string description)
        {
            //Arrange
            var transType = new TransType()
            {
                RecId = id,
                Name = name,
                Description = description
            };

            //Act
            var response = _controller.Create(transType) as CreatedResult;
            var newtranstype = (TransType)response.Value;

            //Assert
            Assert.IsTrue(condition: HttpStatusCode.Created == (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsNotNull(newtranstype);
            Assert.AreEqual(expected: transType.RecId, actual: newtranstype.RecId);
            Assert.AreEqual(expected: transType.Name, actual: newtranstype.Name);
            Assert.AreEqual(expected: transType.Description, actual: newtranstype.Description);
        }

        [TestMethod]
        public void TransTypeCreate_InValid()
        {
            //Arrange
            var transType = new TransType()
            {
                RecId = null,
                Name = "User1",
                Description = "User1Transactiontype"
            };

            //Act
            var response = _controller.Create(transType) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.ADDERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Transactiontype")]
        [DataRow(1, "User2", "User2Transactiontype")]
        public void TransTypeUpdate_Valid(long id, string name, string description)
        {
            //Arrange
            TransTypeCreate_Valid(id, name, description);

            //Act
            var updatedtransType = new TransType()
            {
                RecId = id,
                Name = "User2",
                Description = "FakeTransactionType"
            };

            var response = _controller.Update(updatedtransType) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Transactiontype")]
        [DataRow(1, "User2", "User2Transactiontype")]
        public void TransTypeUpdate_Invalid(long id, string name, string description, long updatedId)
        {
            //Arrange
            TransTypeCreate_Valid(id, name, description);

            //Act
            var updatedtransType = new TransType()
            {
                RecId = updatedId,
                Name = "User3",
                Description = "FakeTransactionType"
            };

            var response = _controller.Update(updatedtransType) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Transactiontype")]
        [DataRow(1, "User2", "User2Transactiontype")]
        public void TransTypeDelete_Valid(long id, string name, string description)
        {
            //Arrange
            TransTypeCreate_Valid(id, name, description);

            //Act
            var response = _controller.Delete(id) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, "User1", "User1Transactiontype")]
        [DataRow(1, "User2", "User2Transactiontype")]
        public void TransTypeDelete_Invalid(long id, string name, string description)
        {
            //Arrange
            TransTypeCreate_Valid(id, name, description);

            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [TestMethod]
        public void TransTypeFind_Valid()
        {
            //Arrange
            var transType = new TransType()
            {
                RecId = 1,
                Name = "User1",
                Description = "FakeTransactionType"
            };

            TransTypeCreate_Valid(transType.RecId.Value, transType.Name, transType.Description);

            //Act
            var actionResult = _controller.Find(transType.RecId.Value);
            var response = actionResult.Result as OkObjectResult;
            var getTransType = (TransType)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(transType.RecId, getTransType.RecId.Value);
            Assert.AreEqual(transType.Name, getTransType.Name);
            Assert.AreEqual(transType.Description, getTransType.Description);
        }

        [TestMethod]
        public void TransTypeFind_InValid()
        {
            //Arrange
            var transType = new TransType()
            {
                RecId = 1,
                Name = "User1",
                Description = "FakeTransactionType"
            };

            //Act
            var actionResult = _controller.Find(transType.RecId.Value);
            var response = actionResult.Result as NotFoundResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        }

        [TestMethod]
        [DynamicData(nameof(transTypes))]
        public void TransTypeGetAll_Valid(List<TransType> transTypes)
        {
            //Arrange
            for (int i = 0; i < transTypes.Count; i++)
            {
                TransTypeCreate_Valid(transTypes[i].RecId.Value, transTypes[i].Name, transTypes[i].Description);
            }

            //Act
            var response = _controller.GetAll() as OkObjectResult;
            var alltransTypes = (IEnumerable<TransType>)response.Value;
            //Assert

            Assert.IsNotNull(response);
            Assert.AreEqual(transTypes.Count, alltransTypes.Count());
        }

    }
}
