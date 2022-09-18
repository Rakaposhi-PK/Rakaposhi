using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    /// <summary>
    ///     Trans Controller
    /// </summary>
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class TransController : Controller
    {
        /// <summary>
        ///     Trans Service Variable
        /// </summary>
        private TransService _transService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="transService"></param>
        public TransController(TransService transService)
        {
            _transService = transService;
        }

        /// <summary>
        ///     Create Method
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        [HttpPost(Name = "TransCreate")]
        [ProducesResponseType(typeof(Trans), StatusCodes.Status201Created )]
        public ActionResult<Trans> Create([FromBody] Trans trans)
        {
            try
            {
                _transService.Add(trans);

                return Created("Get", trans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Update Method
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        [HttpPut(Name = "TransUpdate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update([FromBody] Trans trans)
        {
            try
            {
                _transService.Update(trans);

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
        [HttpDelete("{id}", Name = "TransDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(long id)
        {
            try
            {
                _transService.Delete(id);

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
        [HttpGet("{id}", Name = "TransFind")]
        public ActionResult<Trans> Find(long id)
        {
            try
            {
                var found = _transService.Find(id);
               
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
        [HttpGet(Name = "TransGetAll")]
        public ActionResult<List<Trans>> GetAll()
        {
            try
            {
                var transList = _transService.GetAll();

                return Ok(transList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}