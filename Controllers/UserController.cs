using HNG_Backend_Stage_Two_User_Auth;
using HNG_Backend_Stage_Two_User_Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService userService = userService;

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
