using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Business.Interfaces;
using TinyURL2.Business.Models.ViewModels;
using TinyURL2.Models.Entities;

namespace TinyURL2.Business.Services
{
    public class UrlService : IUrlService
    {
        private readonly IGenericRepository<Url> _urlRepository;
        public UrlService(IGenericRepository<Url> urlRepository)
        {
            _urlRepository = urlRepository;
        }
        public UrlVM CreateRandomShortUrl(string longUrl)
        {
            var newCode = Guid.NewGuid().ToString().Substring(0, 6);
            var url = new Url
            {
                OriginalUrl = longUrl,
                Code = newCode,                
                Clicks = 0,                
            };
            _urlRepository.Add(url);
            _urlRepository.SaveChanges();
            return new UrlVM
            {
                Id = url.Id,
                CreatedAt = url.CreatedAt,
                UpdatedAt = url.UpdatedAt,
                CreatedBy = new AccountVM
                {
                    Id = url.CreatedBy,
                },
                UpdatedBy = new AccountVM
                {
                    Id = url.CreatedBy,
                },
                Code = url.Code,
                LongUrl = url.OriginalUrl,
                ShortUrl = url.FullUrl,
                Clicks = url.Clicks
            };
        }

        public bool DeleteUrl(Guid id)
        {
            var result = _urlRepository.Delete(id);
            return result;
        }

        public string GetUrlByCode(string code)
        {
            var url = _urlRepository.AsQueryable().FirstOrDefault(x => x.Code == code);
            if (url is null)
            {
                return string.Empty;
            }
            url.Clicks++;
            _urlRepository.Update(url);
            _urlRepository.SaveChanges();
            return url.OriginalUrl;
        }

        public UrlVM? GetUrlById(Guid id)
        {
            var url = _urlRepository.GetById(id);
            if (url is null)
            {
                return null;
            }
            return Map(url);
        }
       
        public UrlVM? UpdateExistingUrl(Guid id, string longUrl)
        {
            var url = _urlRepository.GetById(id);
            if (url is null)
            {
                return null;
            }
            url.OriginalUrl = longUrl;
            _urlRepository.Update(url);
            _urlRepository.SaveChanges();
            return Map(url);
        }

        internal UrlVM Map(Url url)
        {
            UrlVM vm = new()
            {
                Id = url.Id,
                CreatedAt = url.CreatedAt,
                UpdatedAt = url.UpdatedAt,
                CreatedBy = new AccountVM
                {
                    Id = url.CreatedBy,
                },
                UpdatedBy = new AccountVM
                {
                    Id = url.CreatedBy,
                },
                Code = url.Code,
                Clicks = url.Clicks,
                LongUrl = url.OriginalUrl,
                ShortUrl = url.FullUrl
            };
            return vm;
        }
    }
}
