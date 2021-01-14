using Microsoft.AspNetCore.Mvc;

namespace mr.cooper.mrtwit.api.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("ping Success");
        }
    }
}
