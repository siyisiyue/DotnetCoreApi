using DotnetCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [EnableCors("any")]
    public class UserController : ControllerBase
    {
        private readonly TodoContext _context;
        public UserController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<UserInfo> GetUserInfo()
        {
            var userName = Response.HttpContext.User.Identity.Name;
            var userInfo =  _context.UserInfo.Where(x => x.UserName == userName).FirstOrDefault();
            return userInfo;
        }
    }
}
