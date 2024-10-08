using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TinyURL2.Business.Interfaces;
using TinyURL2.Business.Models.ViewModels;

namespace TinyURL2.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IHttpClientFactory _httpClientFactory;
        public UrlController(IUrlService urlService, IHttpClientFactory httpClientFactory)
        {
            _urlService = urlService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(UrlVM))]
        public IActionResult Get([FromQuery]Guid id)
        {
            var url = _urlService.GetUrlById(id);
            if (url == null)
            {
                return NotFound();
            }
            return Ok(url);
        }

        //[HttpPost]
        //[ProducesResponseType(statusCode: StatusCodes.Status201Created, Type = typeof(UrlVM))]
        //public async Task<IActionResult> TestGeminiApi([FromBody] string request)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var key = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
        //    var json = "{\"contents\":[{\"parts\":[{\"text\":\"Explain how AI works\"}]}]}";
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(
        //        $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={key}", 
        //        content);
        //    return Ok(response.Content);
        //}

        [HttpPost]
        public IActionResult Create([FromBody] string url)
        {
            var result = _urlService.CreateRandomShortUrl(url);
            return Ok(result);
        }

        [HttpGet("{code}")]
        public IActionResult AccessFullUrl([FromRoute] string code)
        {
            var url = _urlService.GetUrlByCode(code);
            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }
            return Redirect(url);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] string newUrl)
        {
            if (string.IsNullOrWhiteSpace(newUrl))
            {
                return BadRequest(); 
            }
            var result = _urlService.UpdateExistingUrl(id, newUrl);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
