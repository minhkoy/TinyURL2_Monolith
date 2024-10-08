using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Business.Models.ViewModels;

namespace TinyURL2.Business.Interfaces
{
    public interface IUrlService
    {
        /// <summary>
        /// Create a new short URL.
        /// </summary>
        UrlVM CreateRandomShortUrl(string longUrl);
        string GetUrlByCode(string code);
        UrlVM? GetUrlById(Guid id);
        UrlVM? UpdateExistingUrl(Guid id, string longUrl);
        bool DeleteUrl(Guid id);        
    }
}
