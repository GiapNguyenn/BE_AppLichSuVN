using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;
using HistoryAPI.Data;

namespace HistoryAPI.Controllers
{
    [Route("api/su-kien")]
    [ApiController]
    public class SuKienController : ControllerBase
    {
        private readonly HistoryDbContext _context;

        public SuKienController(HistoryDbContext context)
        {
            _context = context;
        }

        // GET: api/su-kien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuKien>>> GetSuKiens()
        {
            return await _context.SuKiens.Include(s => s.ThoiKyQuocHieu).ToListAsync(); // Include triều đại
        }

        // GET: api/su-kien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuKien>> GetSuKien(int id)
        {
            var suKien = await _context.SuKiens.Include(s => s.ThoiKyQuocHieu).FirstOrDefaultAsync(s => s.MaSuKien == id); // Include triều đại

            if (suKien == null)
            {
                return NotFound();
            }

            return suKien;
        }

        // POST: api/su-kien
        [HttpPost]
        public async Task<ActionResult<SuKien>> PostSuKien(SuKien suKien)
        {
            _context.SuKiens.Add(suKien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuKien), new { id = suKien.MaSuKien }, suKien);
        }

        // PUT: api/su-kien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuKien(int id, SuKien suKien)
        {
            if (id != suKien.MaSuKien)
            {
                return BadRequest();
            }

            _context.Entry(suKien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuKienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/su-kien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuKien(int id)
        {
            var suKien = await _context.SuKiens.FindAsync(id);
            if (suKien == null)
            {
                return NotFound();
            }

            _context.SuKiens.Remove(suKien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuKienExists(int id)
        {
            return _context.SuKiens.Any(e => e.MaSuKien == id);
        }
    }
}