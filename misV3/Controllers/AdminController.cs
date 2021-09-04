using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using misV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace misV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        //GET : /api/Admin
        public async Task<ActionResult<IEnumerable<ApplicationUserModel>>> getAdmins()
        {
            var users = await _userManager.Users.Select(s => new ApplicationUserModel
            { 
                FullName = s.FullName,
                UserName = s.UserName,
                Password = s.PasswordHash
            }).ToListAsync();
            return Ok(users);
        }
    }
}
