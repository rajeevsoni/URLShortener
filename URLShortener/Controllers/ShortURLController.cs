using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortURLController : ControllerBase
    {
        private readonly ILogger<ShortURLController> _logger;

        public ShortURLController(ILogger<ShortURLController> logger)
        {
            _logger = logger;
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
        public async Task<IActionResult> Post()
        {
            await Task.Delay(10);
            return Ok("tiny url");
        }

        /// <summary>
        /// Update short URL for input URL.
        /// </summary>
        /// <remarks>
        /// ### Usage Notes ###
        /// 1. A valid User with jwt
        /// </remarks>
        /// <response code="200">With short url</response>
        /// <response code="401">Unauthorized.</response>
        [HttpPost]
        public async Task<IActionResult> Update()
        {
            await Task.Delay(10);
            return Ok("tiny url");
        }
    }
}
