using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class TransTypeController : Controller
    {
        private TransTypeService _transTypeService;

        public TransTypeController(TransTypeService transTypeService)
        {
            _transTypeService = transTypeService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] TransType transactionTypes)
        {
            try
            {
                _transTypeService.Add(transactionTypes);
                return Created("Get", transactionTypes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult Update([FromBody] TransType transactionTypes)
        {
            try
            {
                _transTypeService.Update(transactionTypes);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
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

        [HttpGet("{id}")]
        public ActionResult<TransType> Find(long id)
        {
            var found = _transTypeService.Find(id);
            try
            {
                if (found != null)
                {
                    return Ok(found);
                }

                return NotFound();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var transactionTypesList = _transTypeService.GetAll();
                return Ok(transactionTypesList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
