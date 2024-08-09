using MCF_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCF_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpkbController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BpkbController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBpkb([FromBody] TrBpkb bpkb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrBpkbs.Add(bpkb);
            await _context.SaveChangesAsync();

            return Ok(bpkb);
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _context.MsStorageLocations.ToListAsync();
            return Ok(locations);
        }
    }
}
