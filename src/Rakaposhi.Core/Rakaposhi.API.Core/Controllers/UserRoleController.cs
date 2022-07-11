using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    [Route(Global.APICONTROLLER)]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private UserRoleService _userRoleService;

        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        // POST api/<UserRoleController>
        [HttpPost]
        public ActionResult Create([FromBody] UserRole userRole)
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

        // PUT api/<UserRoleController>/5
        [HttpPut]
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

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        public string Find(long id)
        {
            return "value";
        }

        // GET: api/<UserRoleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
