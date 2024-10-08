using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Business.Models.DTOs.Urls
{
    public record UpdateUrlInput
    {
        public string? Code { get; set; }
        public string? OriginalUrl { get; set; }
        public string? LongUrl { get; set; }
    }
}
