using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Business.Interfaces;
using TinyURL2.Business.Models.DTOs;
using TinyURL2.Business.Models.ViewModels;

namespace TinyURL2.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public LoginVM Login(LoginDto request)
        {
            
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public string RequestOTP(string username, string email)
        {
            throw new NotImplementedException();
        }

        public void SignUp(SignUpDto request)
        {
            throw new NotImplementedException();
        }
    }
}
