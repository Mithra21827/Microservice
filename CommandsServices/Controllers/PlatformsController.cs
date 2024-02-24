using Microsoft.AspNetCore.Mvc;

namespace CommandsServices.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController() { }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Indound Post #Command Service");
            return Ok("Inbound test from platfrom controller");
        }
    }
}
