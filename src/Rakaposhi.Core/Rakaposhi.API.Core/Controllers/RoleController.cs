using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    /// <summary>
    ///     Role Controller
    /// </summary>
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class RoleController : Controller
    {
        /// <summary>
        ///     Role Service Variable
        /// </summary>
        private RoleService _roleService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="roleService"></param>
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        ///     Create Method
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost(Name = "RoleCreate")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status201Created)]
        public ActionResult<Role> Create([FromBody] Role roles)
        {
            try
            {
                _roleService.Add(roles);

                return Created("Get", roles);

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
        [HttpPut(Name = "RoleUpdate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update([FromBody] Role userStatus)
        {
            try
            {
                _roleService.Update(userStatus);

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
        [HttpDelete("{id}", Name = "RoleDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(long id)
        {
            try
            {
                _roleService.Delete(id);

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
        [HttpGet("{id}", Name = "RoleFind")]
        public ActionResult<Role> Find(long id)
        {
            try
            {
                var found = _roleService.Find(id);

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
        [HttpGet(Name = "RoleGetAll")]
        public ActionResult<List<Role>> GetAll()
        {
            try
            {
                var found = _roleService.GetAll();

                return Ok(found);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
