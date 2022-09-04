using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class TransController : Controller
    {
        private TransService _transService;

        public TransController(TransService transService)
        {
            _transService = transService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] Trans trans)
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

        [HttpPut]
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

        [HttpDelete("{id}")]
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

        [HttpGet("{id}")]
        public ActionResult<UserStatus> Find(long id)
        {
            var found = _transService.Find(id);

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
                var userStatusList = _transService.GetAll();

                return Ok(userStatusList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}