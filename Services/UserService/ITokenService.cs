using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.UserService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}