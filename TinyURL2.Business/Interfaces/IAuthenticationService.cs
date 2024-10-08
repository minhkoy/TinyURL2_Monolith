using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Business.Models.DTOs;
using TinyURL2.Business.Models.ViewModels;

namespace TinyURL2.Business.Interfaces
{
    public interface IAuthenticationService
    {
        LoginVM Login(LoginDto request);
        bool Logout();
        string RequestOTP(string username, string email);
        void SignUp(SignUpDto request);
        

        //LoginResponse RefreshToken(string refreshToken);
    }
}
