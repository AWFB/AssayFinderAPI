using Microsoft.AspNetCore.Identity;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(RegisterUserDTO userForRegistration);
        Task<bool> ValidateUser(UserForAuthDTO userForAuth);
        Task<string> CreateToken();
    }
}
