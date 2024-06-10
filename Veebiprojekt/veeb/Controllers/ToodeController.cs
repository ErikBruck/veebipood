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
            new Toode(1, "Shutter Island", 8.2, 2010)
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

    }
}
