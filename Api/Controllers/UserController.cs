using Api.Data;
using Api.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Datacontext _context;

        public UserController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GerUsers()
        {
            try
            {
                var users = await _context.AppUsers.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        [HttpGet("{id}")]
        public async  Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.AppUsers.FindAsync (id);
            
        }
    }
}
