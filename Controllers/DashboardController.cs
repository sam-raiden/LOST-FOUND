using Microsoft.AspNetCore.Mvc;
using CampusLostFound.Api.Data;

namespace CampusLostFound.Api.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStats()
        {
            var totalLost = _context.LostItems.Count();
            var totalFound = _context.FoundItems.Count();
            var resolved = _context.LostItems.Count(x => x.Status == "Resolved") +
                           _context.FoundItems.Count(x => x.Status == "Resolved");

            return Ok(new
            {
                totalLost,
                totalFound,
                resolved,
                pending = (totalLost + totalFound) - resolved
            });
        }
    }
}
