using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Business.Models.ViewModels
{
    public class UrlVM : BaseVM
    {
        public string? Code { get; set; }
        public string? LongUrl { get; set; }
        public string? ShortUrl { get; set; }
        public int? Clicks { get; set; }
    }
}
