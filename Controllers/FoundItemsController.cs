using Microsoft.AspNetCore.Mvc;
using CampusLostFound.Api.Data;
using CampusLostFound.Api.Models;

namespace CampusLostFound.Api.Controllers
{
    [ApiController]
    [Route("api/found")] // 🔥 CORRECT ROUTE
    public class FoundItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FoundItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.FoundItems.ToList());
        }

        [HttpPost]
        public IActionResult Create([FromBody] FoundItem item) // 🔥 FIX
        {
            item.Status = "Pending";
            _context.FoundItems.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPut("{id}/resolve")]
        public async Task<IActionResult> Resolve(int id)
        {
            var item = await _context.FoundItems.FindAsync(id);
            if (item == null)
                return NotFound();

            item.Status = "Resolved";
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
