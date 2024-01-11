using Api.Data;
using Api.DTos;
using Api.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
    public class AccountContoller : BaseApiController
    {
        private readonly Datacontext _context;
        public AccountContoller(Datacontext context)
        {
            _context = context;

        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserExits(registerDto.Username)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Name = registerDto.Username.ToLower(),
                //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                //passwordSalt = hmac.Key
                passwordSalt=registerDto.Password+"Salt",
                PasswordHash=registerDto.Password+"Hash"

            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private async Task<bool> UserExits(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.Name == username.ToLower());
        }

    }

}
