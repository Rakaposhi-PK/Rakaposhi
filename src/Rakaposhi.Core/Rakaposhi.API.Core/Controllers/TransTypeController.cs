using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    /// <summary>
    ///     TransType Controller
    /// </summary>
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class TransTypeController : Controller
    {
        /// <summary>
        ///     TransType Service Variable
        /// </summary>
        private TransTypeService _transTypeService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="transTypeService"></param>
        public TransTypeController(TransTypeService transTypeService)
        {
            _transTypeService = transTypeService;
        }

        /// <summary>
        ///     Create Method
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        [HttpPost(Name = "TransTypeCreate")]
        [ProducesResponseType(typeof(TransType), StatusCodes.Status201Created)]
        public ActionResult<TransType> Create([FromBody] TransType transactionType)
        {
            try
            {
                _transTypeService.Add(transactionType);

                return Created("Get", transactionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Update Method
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        [HttpPut(Name = "TransTypeUpdate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update([FromBody] TransType transactionType)
        {
            try
            {
                _transTypeService.Update(transactionType);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "TransTypeDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(long id)
        {
            try
            {
                _transTypeService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Find Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "TransTypeFind")]
        public ActionResult<TransType> Find(long id)
        {
            try
            {
                var found = _transTypeService.Find(id);

                return Ok(found);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     GetAll Method
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "TransTypeGetAll")]
        public ActionResult<List<TransType>> GetAll()
        {
            try
            {
                var transactionTypeList = _transTypeService.GetAll();

                return Ok(transactionTypeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}