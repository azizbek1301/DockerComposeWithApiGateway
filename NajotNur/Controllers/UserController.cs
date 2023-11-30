using Microsoft.AspNetCore.Mvc;
using NajotNur.Domain.Models;
using NajotNur.Infrastructure;

namespace NajotNur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult Post(User userDto)
        {
            var valueEntry = _context.Users.Add(userDto);
            _context.SaveChanges();
            return Ok(valueEntry.Entity);
        }
    }
}
