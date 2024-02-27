using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorHistoricsController(OccurrenceTriggerContext context) : ControllerBase
    {
        private readonly OccurrenceTriggerContext _context = context;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndicatorHistoric>>> GetHistoric()
        {
            return await _context.IndicatorHistorics.ToListAsync();
        }

        [HttpGet("{indicatorId}")]
        public async Task<ActionResult<IndicatorHistoric>> GetIndicatorHistoric(string indicatorId)
        {
            var indicators = await _context.IndicatorHistorics.FindAsync(indicatorId);

            if (indicators is null) return NotFound();

            return indicators;
        }

        [HttpPost]
        public async Task<ActionResult<IndicatorHistoric>> PostIndicatorHistoric([FromBody] IndicatorHistoric indicatorHistoric)
        {
            _context.IndicatorHistorics.Add(indicatorHistoric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicatorHistoric", new { indicatorId = indicatorHistoric.IndicatorId }, indicatorHistoric);
        }
    }
}
