using DotnetCoreApi.Dtos;
using DotnetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi
{
    public class UserService : IUserService
    {
        private readonly TodoContext _context;
        public UserService(TodoContext context)
        {
            _context = context;
        }
        //模拟测试，默认都是人为验证有效
        public bool IsValid(LoginRequestDTO req)
        {
            var result = _context.UserInfo.Where(x => x.UserName == req.Username && x.Password == req.Password).FirstOrDefault();
            if (result==null)
            {
                return false;
            }
            return true;
        }
    }
}
