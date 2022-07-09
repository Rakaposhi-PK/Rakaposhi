using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rakaposhi.API.Core.JWTauthentication;

namespace Rakaposhi.API.Core.Controllers
{
    [Authorize]
    [ApiController]
    [Route(Global.APICONTROLLER)]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public WeatherForecastController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
            {
                "Maaz  Khanh",
                "Computer Scientist",
                "Adil Ayub"
            };

            return users;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}