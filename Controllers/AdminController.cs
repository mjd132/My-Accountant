using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using p1.DTO;
using p1.Intefaces;

namespace p1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase

    {
        private readonly IUserRepository userRepository;
        public AdminController(IUserRepository _userRepository)
        {
             userRepository = _userRepository;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {   
            
            return Ok(userRepository.GetUsers());
        }

        //[HttpPost("AddUser")]
        //public IActionResult AddUser(RegisterDto request)
        //{
        //    return 
        //}
    }
}
