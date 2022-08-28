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
                                Amount = 2300,
                                Date = DateTime.Now,
                            },
                            new Trans()
                            {
                                RecId = 2,
                                UserId = 1,
                                Transtype = 1,
                                Amount = 2300,
                                Date = DateTime.Now,
                            },
                            new Trans()
                            {
                                RecId = 3,
                                UserId = 1,
                                Transtype = 1,
                                Amount = 2300,
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
        [DataRow(1, 1, 1, 2323, "22-08-2022")]
        [DataRow(2, 1, 1, 2323, "22-08-2022")]
        [DataRow(3, 1, 1, 2323, "22-08-2022")]

        [TestMethod]
        public void TransCreate_Valid(long recId, long userId, long transType, int amount, string date)
        {
            //Arrange
            var trans = new Trans()
            {
                RecId = recId,
                UserId = userId,
                Transtype = transType,
                Amount = Convert.ToDecimal(amount),
                Date = Convert.ToDateTime(date)
            };

            //Act
            var response = _controller.Create(trans) as CreatedResult;
            var newTrans = (Trans)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
            Assert.IsNotNull(value: newTrans);
            Assert.AreEqual(expected: newTrans.RecId, actual: newTrans.RecId);
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
                Amount = Convert.ToDecimal(123),
                Date = Convert.ToDateTime("22-08-2022")
            };

            //Act
            var response = _controller.Create(trans) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.ADDERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 2323, "22-08-2022")]
        [DataRow(2, 1, 1, 2323, "22-08-2022")]
        [TestMethod]

        public void TransUpdate_Valid(long recId, long userId, long transType, int amount, string date)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType, amount, date);

            //Act
            var updatedTrans = new Trans()
            {
                RecId = recId,
                UserId = 2,
                Transtype = 2,
                Amount = 123,
                Date = Convert.ToDateTime(date)
            };

            var response = _controller.Update(updatedTrans) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 2323, "22-08-2022", 2)]
        [DataRow(1, 1, 1, 2323, "22-08-2022", 3)]
        [TestMethod]

        public void RoleUpdate_Invalid(long recId, long userId, long transType, int amount, string date, long updatedId)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType, amount, date);

            //Act
            var updatedTrans = new Trans()
            {
                RecId = updatedId,
                UserId = 2,
                Transtype = 3,
                Amount = 123,
                Date = Convert.ToDateTime(date)
            };

            var response = _controller.Update(updatedTrans) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.UPDATEERROR, response.Value.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 2323, "22-08-2022")]
        [DataRow(2, 1, 1, 2300, "22-08-2022")]
        [TestMethod]

        public void TransDelete_Valid(long recId, long userId, long transType, int amount, string date)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType, amount, date);

            //Act
            var response = _controller.Delete(recId) as NoContentResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 2323, "22-08-2022")]
        [DataRow(2, 1, 1, 2300, "22-08-2022")]
        [TestMethod]

        public void TransDelete_Invalid(long recId, long userId, long transType, int amount, string date)
        {
            //Arrange
            TransCreate_Valid(recId, userId, transType, amount, date);

            //Act
            var response = _controller.Delete(3) as BadRequestObjectResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(ErrorCode.DELETEERROR, response.Value.ToString());
        }

        [TestMethod]
        public void TransFind_Valid()
        {
            //Arrange
            var trans = new Trans()
            {
                RecId = 1,
                UserId = 1,
                Transtype = 1,
                Amount = 123,
                Date = DateTime.Now
            };

            TransCreate_Valid(trans.RecId.Value, trans.UserId, trans.Transtype, Convert.ToInt32(trans.Amount), trans.Date.ToString());

            //Act
            var actionResult = _controller.Find(trans.RecId.Value);
            var response = actionResult.Result as OkObjectResult;
            var getTrans = (Trans)response.Value;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(trans.RecId, getTrans.RecId.Value);
            Assert.AreEqual(trans.Amount, getTrans.Amount);
        }

        [TestMethod]
        public void TransFind_InValid()
        {
            //Arrange
            var trans = new Trans()
            {
                RecId = 1,
                UserId = 1,
                Transtype = 1,
                Amount = 123,
                Date = DateTime.Now
            };

            //Act
            var actionResult = _controller.Find(trans.RecId.Value);
            var response = actionResult.Result as NotFoundResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)response.StatusCode);
        }

        [TestMethod]
        [DynamicData(nameof(transactions))]
        public void TransGetAll_Valid(List<Trans> transactions)
        {
            //Arrange
            for (int i = 0; i < transactions.Count; i++)
            {
                TransCreate_Valid(transactions[i].RecId.Value, transactions[i].UserId, transactions[i].Transtype, Convert.ToInt32(transactions[i].Amount), transactions[i].Date.ToString());
            }

            //Act
            var response = _controller.GetAll() as OkObjectResult;
            var allTransactions = (IEnumerable<Trans>)response.Value;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(transactions.Count, allTransactions.Count());
        }
    }
}