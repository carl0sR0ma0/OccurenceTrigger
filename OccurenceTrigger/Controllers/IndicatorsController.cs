using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController(OccurrenceTriggerContext context) : ControllerBase
    {
        private readonly OccurrenceTriggerContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicator>>> GetIndicators()
        {
            return await _context.Indicators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Indicator>> GetIndicator(int id)
        {
            var indicators = await _context.Indicators.FindAsync(id);

            if (indicators is null) return NotFound();

            return indicators;
        }

        [HttpPost]
        public async Task<ActionResult<Indicator>> PostIndicator([FromBody] Indicator indicator)
        {
            _context.Indicators.Add(indicator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicator", new { id = indicator.Id }, indicator);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Indicator>> PutIndicator(int id, [FromBody] Indicator indicator)
        {
            var indicatorFounded = await _context.Indicators.FindAsync(id);

            if (indicatorFounded is not null) {
                indicatorFounded.Name = indicator.Name; 
                indicatorFounded.Area = indicator.Area; 
                
                _context.Indicators.Update(indicatorFounded);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicator", new { id = indicator.Id }, indicator);
        }
    }
}
