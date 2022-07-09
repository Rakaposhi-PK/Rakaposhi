using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Business.Core.Services;

namespace Rakaposhi.API.Core.Controllers
{
    [Authorize]
    [ApiController]
    [Route(Global.APICONTROLLER)]
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] User u)
        {
            try
            {
                _userService.Add(u);
                return Created("Get", u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Edit([FromBody] User u)
        {
           try
           {
               _userService.Add(u);
               return NoContent();
           }
           catch(Exception ex)
           {
                return BadRequest(ex.Message);
           }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(long Id)
        {
            try
            {
                _userService.Delete(Id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<User> Find(int Id)
        {
            try
            {
                var found = _userService.Find(Id);

                return Ok(found);
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
                var users = _userService.GetAll();
                return Ok(users);
           }
           catch(Exception ex)
           {
                return BadRequest(ex.Message);
           }
        }

    }
}
