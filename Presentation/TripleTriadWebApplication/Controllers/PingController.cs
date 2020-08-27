using System;
using Microsoft.AspNetCore.Mvc;

namespace TripleTriadWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private static readonly Guid InstanceId = Guid.NewGuid();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                now = DateTime.Now,
                instanceId = InstanceId
            });
        }
    }
}