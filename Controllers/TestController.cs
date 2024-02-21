using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p1.Repository.context;

namespace p1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly EntitiesDbContext _context;
        public TestController(EntitiesDbContext entitiesDbContext)
        {
            _context = entitiesDbContext;
        }
        [HttpGet("getDebts")]
        public IActionResult test(string Username)
        {
            return Ok(_context.Users.FirstOrDefault(u => u.userName == Username).MadarKharjis.ToList());
        }
    }
}
