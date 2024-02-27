using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerConfigurationsController(OccurrenceTriggerContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TriggerConfiguration>>> GetTriggerConfigurations()
        {
            return await context.TriggerConfigurations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TriggerConfiguration>> GetTriggerConfiguration(int id)
        {
            var triggerConfiguration = await context.TriggerConfigurations.FindAsync(id);

            if (triggerConfiguration is null) return NotFound();

            return triggerConfiguration;
        }

        [HttpPost]
        public async Task<ActionResult<TriggerConfiguration>> PostTriggerConfiguration(TriggerConfiguration configuracaoGatilho)
        {
            context.TriggerConfigurations.Add(configuracaoGatilho);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTriggerConfiguration", new { id = configuracaoGatilho.Id }, configuracaoGatilho);
        }
    }
}
