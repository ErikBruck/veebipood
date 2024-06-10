using Microsoft.AspNetCore.Mvc;
using veeb.models;
using System.Collections.Generic;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1, "Koola", 1.5, true),
            new Toode(2, "Fanta", 1.0, false),
            new Toode(3, "Sprite", 1.7, true),
            new Toode(4, "Vichy", 2.0, true),
            new Toode(5, "Vitamin well", 2.5, true)
        };

        // GET https://localhost:4444/tooted
        [HttpGet]
        public ActionResult<List<Toode>> Get()
        {
            return Ok(_tooted);
        }

        // DELETE https://localhost:4444/tooted/kustuta/{index}
        [HttpDelete("kustuta/{index}")]
        public ActionResult<List<Toode>> Delete(int index)
        {
            if (index < 0 || index >= _tooted.Count)
            {
                return NotFound("Index out of range");
            }
            _tooted.RemoveAt(index);
            return Ok(_tooted);
        }

        // POST https://localhost:4444/tooted/lisa
        [HttpPost("lisa")]
        public ActionResult<List<Toode>> Add([FromBody] Toode uusToode)
        {
            _tooted.Add(uusToode);
            return Ok(_tooted);
        }

        // PATCH https://localhost:4444/tooted/hind-dollaritesse/{kurss}
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public ActionResult<List<Toode>> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price *= kurss;
            }
            return Ok(_tooted);
        }
    }
}
