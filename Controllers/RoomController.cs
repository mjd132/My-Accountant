using Microsoft.AspNetCore.Mvc;
using p1.DTO;
using p1.Intefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRoomRepository _userRoomRepository;
        public RoomController(IRoomRepository roomRepository, IUserRoomRepository userRoomRepository)
        {
            _roomRepository = roomRepository;
            _userRoomRepository = userRoomRepository;
        }
        // GET: api/<RoomController>
        [HttpGet("GetMembers")]
        public async Task<ICollection<GetMembersDto>> GetMembers(long? id, string? code)
        {
            if(id == null && code == null)
            {
                return await Task.FromResult(new List<GetMembersDto>());
            }
            ICollection<GetMembersDto> userdto =await _roomRepository.GetMembers(id, code);
            return await Task.FromResult(userdto);
        }

        // GET api/<RoomController>/5
        [HttpGet("GetAllRooms")]
        public IActionResult GetAll()
        {

            return Ok(_roomRepository.GetAll());
        }

        // POST api/<RoomController>
        // Create Room
        [HttpPost("CreateRoom")]
        public IActionResult Post( string nameRoom,string usernameAdmin)
        {
            if (nameRoom == null)
                return BadRequest("empty form!");
            _roomRepository.InsertRoom(nameRoom, usernameAdmin);
            return Ok();
        }

        [HttpPost("Join")]
        public IActionResult Join(string code,string username)
        {

            if (username == null || code == null)
            {
                return BadRequest("Null Args. username or roomcode is null ");
            }
            
            if(_userRoomRepository.JoinUserToRoom(username, code))
                return Ok();
            return BadRequest("A Error occurded!(join-RoomController)");
        }
        [HttpDelete("Leave")]
        public IActionResult Leave(string username)
        {
            if (username == null)
                return BadRequest("username is null");
            _userRoomRepository.LeaveUserFromRoom(username);
            return Ok();
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("Delete/{code}")]
        public IActionResult Delete(string code)
        {
            if (code == null)
                return BadRequest("Code is null!");
            if (_roomRepository.DeleteRoom(code))
                return Ok();
            else return BadRequest("operation failed!");
        }
    }
}
