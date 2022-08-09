using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class UserStatusController : Controller
    {
        private UserStatusService _userStatusService;

        public UserStatusController(UserStatusService userStatusService)
        {
            _userStatusService = userStatusService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] UserStatus userStatus)
        {
            try
            {
                _userStatusService.Add(userStatus);
                return Created("Get", userStatus);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult Update([FromBody] UserStatus userStatus)
        {
            try
            {
                _userStatusService.Update(userStatus);
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
                _userStatusService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserStatus> Find(long id)
        {
            var found = _userStatusService.Find(id);
            try
            {
                if (found !=null)
                {
                    return Ok(found);
                }

                return NotFound();
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var userStatusList = _userStatusService.GetAll();
                return Ok(userStatusList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
