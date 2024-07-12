using Microsoft.AspNetCore.Mvc;

namespace PaymentAdvisoryPortalParentAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to Parent API of Payment Advisory Portal");
        }
    }
}