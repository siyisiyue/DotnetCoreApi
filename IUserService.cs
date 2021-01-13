using DotnetCoreApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi
{
    public  interface IUserService
    {
        bool IsValid(LoginRequestDTO req);
    }
}
