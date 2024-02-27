using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccurrencesController(OccurrenceTriggerContext context) : ControllerBase
    {
        private readonly OccurrenceTriggerContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occurrence>>> GetOccurrences()
        {
            return await _context.Occurrences.ToListAsync();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteOccurrences()
        {
            await _context.Occurrences.ExecuteDeleteAsync();
            return 1;
        }
    }
}
