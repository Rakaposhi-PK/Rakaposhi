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

        // GET: UserController/Create
        [HttpPost]
        public ActionResult Create([FromBody] User u)
        {
            return View();
        }


        // GET: UserController/Edit/5
        [HttpPut]
        public ActionResult Edit([FromBody] User u)
        {
            return View();
        }

        // GET: UserController/Delete/5
        [HttpDelete("{Id}")]
        public ActionResult Delete(long Id)
        {
            return View();
        }

        [HttpGet("{Id}")]
        public ActionResult Find(int Id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult<User> GetAll()
        {
            return View();
        }

    }
}
