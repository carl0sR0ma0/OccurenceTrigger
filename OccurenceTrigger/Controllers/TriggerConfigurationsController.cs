using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerConfigurationsController(OccurrenceTriggerContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TriggerConfiguration>>> GetTriggerConfigurations()
        {
            return await _context.TriggerConfigurations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TriggerConfiguration>> GetTriggerConfiguration(int id)
        {
            var triggerConfiguration = await _context.TriggerConfigurations.FindAsync(id);

            if (triggerConfiguration is null) return NotFound();

            return triggerConfiguration;
        }

        [HttpPost]
        public async Task<ActionResult<TriggerConfiguration>> PostTriggerConfiguration(TriggerConfiguration triggerConfiguration)
        {
            _context.TriggerConfigurations.Add(triggerConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTriggerConfiguration", new { id = triggerConfiguration.Id }, triggerConfiguration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TriggerConfiguration>> PutTriggerConfiguration(int id, [FromBody] TriggerConfiguration triggerConfiguration)
        {
            var triggerConfigurationFounded = await _context.TriggerConfigurations.FindAsync(id);

            if (triggerConfigurationFounded is not null)
            {
                triggerConfigurationFounded.MinValue = triggerConfiguration.MinValue;
                triggerConfigurationFounded.MaxValue = triggerConfiguration.MaxValue;
                triggerConfigurationFounded.LastValue = triggerConfiguration.LastValue;
                triggerConfigurationFounded.ReferencePercentage = triggerConfiguration.ReferencePercentage;
                triggerConfigurationFounded.AdherenceShift = triggerConfiguration.AdherenceShift;
                triggerConfigurationFounded.Status = triggerConfiguration.Status;

                _context.TriggerConfigurations.Update(triggerConfigurationFounded);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTriggerConfiguration", new { id = triggerConfiguration.Id }, triggerConfiguration);
        }
    }
}
