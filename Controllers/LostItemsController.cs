using Microsoft.AspNetCore.Mvc;
using CampusLostFound.Api.Data;
using CampusLostFound.Api.Models;

namespace CampusLostFound.Api.Controllers
{
    [ApiController]
    [Route("api/lost")]
    public class LostItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LostItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.LostItems.ToList());
        }

        [HttpPost]
        public IActionResult Create([FromBody] LostItem item) // 🔥 FIX
        {
            item.Status = "Pending"; // backend controls this
            _context.LostItems.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPut("{id}/resolve")]
        public async Task<IActionResult> Resolve(int id)
        {
            var item = await _context.LostItems.FindAsync(id);
            if (item == null)
                return NotFound();

            item.Status = "Resolved";
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
