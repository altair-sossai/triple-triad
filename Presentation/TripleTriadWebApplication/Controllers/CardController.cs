using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TripleTriad;
using TripleTriad.Builders;

namespace TripleTriadWebApplication.Controllers
{
    [ApiController, Route("cards")]
    public class CardController : ControllerBase
    {
        private static readonly List<Card> Cards = new List<Card>
        {
            CardBuilder.Build(1).WithPoints(5, 6, 5, 4),
            CardBuilder.Build(2).WithPoints(5, 7, 2, 3),
            CardBuilder.Build(3).WithPoints(3, 6, 2, 6),
            CardBuilder.Build(4).WithPoints(7, 1, 6, 4),
            CardBuilder.Build(5).WithPoints(3, 6, 2, 7),
            CardBuilder.Build(6).WithPoints(4, 6, 9, 10),
            CardBuilder.Build(7).WithPoints(10, 4, 10, 2),
            CardBuilder.Build(8).WithPoints(6, 8, 5, 10),
            CardBuilder.Build(9).WithPoints(2, 9, 6, 10),
            CardBuilder.Build(10).WithPoints(3, 5, 10, 8)
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Cards);
        }
    }
}