using CAT.BusinessLayer.Services.SmileServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Controllers
{
    [Route("api/smiles")]
    public class SmilesController : Controller
    {
        private readonly ISmileService _service;

        public SmilesController(ISmileService service)
        {
            _service = service;
        }

        [HttpGet]
        public string DetectEmotion()
        {
            var emotion = _service.DetectEmotion(null);
            return emotion.ToString();
        }
    }
}
