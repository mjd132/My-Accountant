using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using p1.DTO;
using p1.Intefaces;

namespace p1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // put : update user  / api / Account / {id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> put (long id , UserDto user)
        {
            //user permission and admin permmission for Update database
            if (id != user.Id) return BadRequest("ID not correct");
            
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException) {
                if (!_userRepository.ExistUser(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(user);
        }


        // delete : delete user from database  / api / account/ {id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var user = _userRepository.DeleteById(id);

            return await Task.FromResult(user);
                
        }
        
        
    }
}
