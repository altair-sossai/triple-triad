using Microsoft.AspNetCore.Mvc;
using TripleTriad;
using TripleTriad.Helpers;

namespace TripleTriadWebApplication.Controllers
{
    [ApiController]
    [Route("elements")]
    public class ElementController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EnumHelper.GetValuesAndDescriptions<Element>());
        }
    }
}