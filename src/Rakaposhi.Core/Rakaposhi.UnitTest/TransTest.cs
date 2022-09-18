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
    public class TransTest
    {
        private TransController _controller;

        private static IEnumerable<object[]> transactions
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<Trans>()
                        {
                            new Trans()
                            {
                                RecId = 1,
                                UserId = 1,
                                Transtype = 1,
                                Amount = 2300.9m,
                                Date = DateTime.Now,
                            },
                            new Trans()
                            {
                                RecId = 2,
                                UserId = 1,
                                Transtype = 1,
                                Amount = 2300.9m,
                                Date = DateTime.Now,
                            },
                            new Trans()
                            {
                                RecId = 3,
                                UserId = 1,
                                Transtype = 1,
                                Amount = 2300.9m,
                                Date = DateTime.Now,
                            }
                        }
                    }
                };
            }
        }

        public TransTest()
        {
            IRepositoryFactory factory = new FakeDBRepositoryFactory();
            TransService transService = new TransService(factory);
            _controller = new TransController(transService);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 1)]
        [DataRow(3, 1, 1)]

        [TestMethod]
        public void TransCreate_Valid(long recId, long userId, long transType)
        {
            //Arrange
            decimal amount = 123.8m;

            var trans = new Trans()
            {
                RecId = recId,
                UserId = userId,
                Transtype = transType,
                Amount = amount,
                Date = DateTime.Now
            };

            //Act
            var response = _controller.Create(trans).Result as CreatedResult;
            
            var newTrans = (Trans)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(value: newTrans);
            Assert.AreEqual(trans.RecId, newTrans.RecId);
        }

        [TestMethod]
        public void TransCreate_InValid()
        {
            //Arrange
            var trans = new Trans()
            {
                RecId = null,
                UserId = 1,
                Transtype = 1,
                Amount = 123.4m,
                Date = DateTime.Now
            };

            //Act
            var response = _controller.Create(trans).Result as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.ADDERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 1)]
        [TestMethod]

        public void TransUpdate_Valid(long recId, long userId, long transType)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType);

            //Act
            var updatedTrans = new Trans()
            {
                RecId = recId,
                UserId = 2,
                Transtype = 2,
                Amount = 123.5m,
                Date = DateTime.Now
            };

            var response = _controller.Update(updatedTrans) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 2)]
        [DataRow(1, 1, 1, 3)]
        [TestMethod]

        public void TransUpdate_Invalid(long recId, long userId, long transType, long updatedId)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType);

            //Act
            var updatedTrans = new Trans()
            {
                RecId = updatedId,
                UserId = 2,
                Transtype = 3,
                Amount = 123.5m,
                Date = DateTime.Now
            };

            var response = _controller.Update(updatedTrans) as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 1)]
        [TestMethod]

        public void TransDelete_Valid(long recId, long userId, long transType)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType);

            //Act
            var response = _controller.Delete(recId) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 1)]
        [TestMethod]

        public void TransDelete_Invalid(long recId, long userId, long transType)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType);

            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 1)]
        [TestMethod]
        public void TransFind_Valid(long recId, long userId, long transType)
        {
            TransCreate_Valid(recId, userId, transType);

            //Act
            var actionResult = _controller.Find(recId);
            var response = actionResult.Result as OkObjectResult;
            var getTrans = (Trans)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(recId, getTrans.RecId.Value);
            Assert.AreEqual(userId, getTrans.UserId);
        }

        //[TestMethod]
        //public void TransFind_InValid()
        //{
        //    //Act
        //    var actionResult = _controller.Find(1);
        //    var response = actionResult.Result as NotFoundResult;

        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        //}

        [TestMethod]
        [DynamicData(nameof(transactions))]
        public void TransGetAll_Valid(List<Trans> transactions)
        {
            //Arrange
            for (int i = 0; i < transactions.Count; i++)
            {
                TransCreate_Valid(transactions[i].RecId.Value, transactions[i].UserId, transactions[i].Transtype);
            }

            //Act
            var response = _controller.GetAll().Result as OkObjectResult;
            var allTransactions = (IEnumerable<Trans>)response.Value;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(transactions.Count, allTransactions.Count());
        }
    }
}