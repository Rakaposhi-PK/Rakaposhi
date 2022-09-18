using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    /// <summary>
    ///     UserStatus Controller
    /// </summary>
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class UserStatusController : Controller
    {
        /// <summary>
        ///     UserStatus Service Variable
        /// </summary>
        private UserStatusService _userStatusService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="userStatusService"></param>
        public UserStatusController(UserStatusService userStatusService)
        {
            _userStatusService = userStatusService;
        }

        /// <summary>
        ///     Create Method
        /// </summary>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        [HttpPost(Name = "UserStatusCreate")]
        [ProducesResponseType(typeof(UserStatus), StatusCodes.Status201Created)]
        public ActionResult<UserStatus> Create([FromBody] UserStatus userStatus)
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

        /// <summary>
        ///     Update Method
        /// </summary>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        [HttpPut(Name = "UserStatusUpdate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        /// <summary>
        ///     Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "UserStatusDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        /// <summary>
        ///     Find Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "UserStatusFind")]
        public ActionResult<UserStatus> Find(long id)
        {
            try
            {
                var found = _userStatusService.Find(id);

                return Ok(found);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     GetAll Method
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "UserStatusGetAll")]
        public ActionResult<List<UserStatus>> GetAll()
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
