using Microsoft.AspNetCore.Mvc;
using p1.DTO;
using p1.Intefaces;
using p1.Utilities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository _userRepository, IConfiguration configuration,ITokenHandler tokenHandler)
        {
            userRepository = _userRepository;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
        }


        // POST api/<ValuesController>

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (request.password != request.rePassword)
                return BadRequest("not match password and repassword!");
            if (userRepository.ExistUserName(request.userName))
                return BadRequest("username is exist!");


            UserDto user = new UserDto()
            {
                password = request.password,
                fName = request.fName,
                lName = request.lName,
                userName = request.userName

            };

            userRepository.RegisterUser(user);

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDto request)
        {

            if (request != null && request.userName != null && request.password != null)
            {
                var user = await userRepository.GetUserByUsername(request.userName);
                if (user != null)
                {
                    if (Hashing.MD5Hashing(request.password) == user.password)
                    {
                        
                        return Ok(await _tokenHandler.CreateToken(user));

                    }
                    else
                    {
                        return BadRequest("Password is Wrong!");

                    }
                }
                else
                {
                    return NotFound("Username not exist!");
                }
            }
            else
            {
                return BadRequest(new JsonResult("2004", "Username or Password is Empty"));
            }

        }

    }
}
