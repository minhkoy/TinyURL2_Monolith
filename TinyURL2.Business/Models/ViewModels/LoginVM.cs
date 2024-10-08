using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Business.Models.ViewModels
{
    public class LoginVM
    {
        public required string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
