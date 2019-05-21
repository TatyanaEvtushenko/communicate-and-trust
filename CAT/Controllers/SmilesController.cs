using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SmilesController : Controller
    {
        private readonly ISmileService service;

        public SmilesController(ISmileService service)
        {
            this.service = service;
        }
        
        [HttpGet("detectemotion")]
        public string DetectEmotion()
        {
            var emotion = service.DetectEmotion(null);
            return emotion.ToString();
        }
    }
}
