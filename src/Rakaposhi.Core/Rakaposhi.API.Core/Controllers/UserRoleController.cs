using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    /// <summary>
    ///     UserRole Controller
    /// </summary>
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        /// <summary>
        ///     UserRole Service Variable 
        /// </summary>
        private UserRoleService _userRoleService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="userRoleService"></param>
        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        /// <summary>
        ///     Create Method
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        // POST api/<UserRoleController>
        [HttpPost(Name = "UserRoleCreate")]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status201Created)]
        public ActionResult<UserRole> Create([FromBody] UserRole userRole)
        {
            try
            {
                _userRoleService.Add(userRole);

                return Created("Get", userRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Update Method
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        // PUT api/<UserRoleController>/5
        [HttpPut(Name = "UserRoleUpdadte")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update([FromBody] UserRole userRole)
        {
            try
            {
                _userRoleService.Update(userRole);

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
        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}", Name = "UserRoleDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(long id)
        {
            try
            {
                _userRoleService.Delete(id);

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
        // GET api/<UserRoleController>/5
        [HttpGet("{id}", Name = "UserRoleFind")]
        public ActionResult<UserRole> Find(long id)
        {
            try
            {
                var found = _userRoleService.Find(id);
                
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
        // GET: api/<UserRoleController>
        [HttpGet(Name = "UserRoleGetAll")]
        public ActionResult<List<UserRole>> GetAll ()
        {
            try
            {
                var found = _userRoleService.GetAll();

                return Ok(found);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
