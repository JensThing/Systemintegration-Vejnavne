using Microsoft.AspNetCore.Mvc;
using Vejnavne.CprData.Models;
using Vejnavne.CprData.Services;

namespace Vejnavne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VejnavneController : ControllerBase
    {
        private readonly ICprVejnavneService _cprVejnavne;
        private readonly ILogger<VejnavneController> _logger;

        public VejnavneController(ICprVejnavneService cprVejnavne, ILogger<VejnavneController> logger)
        {
            _cprVejnavne = cprVejnavne;
            _logger = logger;
        }

        [HttpGet("FilterByKommuneKodeAndVejKode/{kommuneKode}/{vejKode}")]
        public IActionResult FilterByKommuneKodeAndVejKode(string kommuneKode, string vejKode)
        {
            // Ensure that the kommuneKode and vejKode are 4 characters long
            if (kommuneKode.Length != 4 || vejKode.Length != 4)
            {
                return BadRequest("KommuneKode and vejKode must be 4 characters long");
            }

            try
            {
                // Filter the records by kommuneKode and vejKode
                return Ok(_cprVejnavne.GetRecords()
                    .OfType<AktVej>()
                    .Where(x => x.Kommunekode.Equals(kommuneKode) && x.Vejkode.Equals(vejKode)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FilterByKommuneKodeAndVejKode");
                return StatusCode(500);
            }
        }

        [HttpGet("FilterByVejnavn/{vejnavn}")]
        public IActionResult FilterByVejnavn(string vejnavn)
        {
            try
            {
                return Ok(_cprVejnavne.GetRecords()
                        .OfType<AktVej>()
                        .Where(x => x.Vejnavn.StartsWith(vejnavn, StringComparison.CurrentCultureIgnoreCase)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FilterByVejnavn");
                return StatusCode(500);
            }
        }
    }
}
