using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using URLShortener.Response;
using URLShortener.Services;

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortURLController : ControllerBase
    {
        private readonly ILogger<ShortURLController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IURLShortenerService _urlShortenerService;
        private const string ServiceURL = "ServiceURL";

        public ShortURLController(ILogger<ShortURLController> logger, IURLShortenerService urlShortenerService, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _urlShortenerService = urlShortenerService;
        }


        /// <summary>
        /// Create short URL for input URL.
        /// </summary>
        /// <remarks>
        /// ### Usage Notes ###
        /// 1. A valid User with jwt
        /// </remarks>
        /// <response code="200">With short url</response>
        /// <response code="401">Unauthorized.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string url)
        {
            bool isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if(!isValidUrl)
            {
                return BadRequest();
            }

            var hashedURL = await _urlShortenerService.SaveURL(url);
            var serviceURL = _configuration.GetValue<string>(ServiceURL);
            var shortURL = String.Concat(serviceURL,"/shorturl/",hashedURL);
            var response = new ShortURLResponse() { ShortURL = shortURL, Code = hashedURL };
            return Ok(response);
        }

        /// <summary>
        /// Redirect to actual URL on providing shirtURL
        /// </summary>
        /// <remarks>
        /// ### Usage Notes ###
        /// 1. A valid User with jwt
        /// </remarks>
        /// <response code="200">With short url</response>
        /// <response code="401">Unauthorized.</response>
        [HttpGet]
        [Route("{shortURL}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Get([FromRoute]string shortURL)
        {
            var url = await _urlShortenerService.GetURL(shortURL);
            if(url == null)
            {
                return NotFound();
            }
            return Redirect(url);
        }
    }
}
