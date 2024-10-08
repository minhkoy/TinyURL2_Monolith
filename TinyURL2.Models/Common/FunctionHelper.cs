using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Models.Common
{
    public static class FunctionHelper
    {
        public static string GetFullUrl(string code)
        {
            return $"{Constants.HOST}/url/{code}";
        }
    }
}
