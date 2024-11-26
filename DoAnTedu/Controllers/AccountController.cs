using DoAnTedu.Dtos.Acccounts;
using DoAnTedu.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoAnTedu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var token = await _service.Login(model);
            
            if (token.IsNullOrEmpty())
            {
                return StatusCode(400, "loi");
            }
            return Ok("Token: "+ token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register model)
        {
            var resualt = await _service.Register(model);

            if (!resualt.Succeeded)
            {
                return StatusCode(400, "loi");
            }
            return Ok("Create User: " + resualt);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _service.GetUser();

            if (user == null)
            {
                return StatusCode(400, "loi");
            }
            return Ok(user);
        }



    }
}
