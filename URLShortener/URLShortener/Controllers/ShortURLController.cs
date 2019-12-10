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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(10);
            return Ok("tiny url");
        }
    }
}
