using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;
using HistoryAPI.Data;

namespace HistoryAPI.Controllers
{
    [Route("api/thoi-ky-quoc-hieu")]
    [ApiController]
    public class ThoiKyQuocHieuController : ControllerBase
    {
        private readonly HistoryDbContext _context;

        public ThoiKyQuocHieuController(HistoryDbContext context)
        {
            _context = context;
        }

        // GET: api/thoi-ky-quoc-hieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThoiKyQuocHieu>>> GetThoiKyQuocHieus()
        {
            return await _context.ThoiKyQuocHieus.ToListAsync();
        }

        // GET: api/thoi-ky-quoc-hieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThoiKyQuocHieu>> GetThoiKyQuocHieu(int id)
        {
            var thoiKyQuocHieu = await _context.ThoiKyQuocHieus.FindAsync(id);

            if (thoiKyQuocHieu == null)
            {
                return NotFound();
            }

            return thoiKyQuocHieu;
        }

        // POST: api/thoi-ky-quoc-hieu
        [HttpPost]
        public async Task<ActionResult<ThoiKyQuocHieu>> PostThoiKyQuocHieu(ThoiKyQuocHieu thoiKyQuocHieu)
        {
            _context.ThoiKyQuocHieus.Add(thoiKyQuocHieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThoiKyQuocHieu), new { id = thoiKyQuocHieu.MaTrieuDai }, thoiKyQuocHieu);
        }

        // PUT: api/thoi-ky-quoc-hieu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThoiKyQuocHieu(int id, ThoiKyQuocHieu thoiKyQuocHieu)
        {
            if (id != thoiKyQuocHieu.MaTrieuDai)
            {
                return BadRequest();
            }

            _context.Entry(thoiKyQuocHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThoiKyQuocHieuExists(id))
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

        // DELETE: api/thoi-ky-quoc-hieu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThoiKyQuocHieu(int id)
        {
            var thoiKyQuocHieu = await _context.ThoiKyQuocHieus.FindAsync(id);
            if (thoiKyQuocHieu == null)
            {
                return NotFound();
            }

            _context.ThoiKyQuocHieus.Remove(thoiKyQuocHieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThoiKyQuocHieuExists(int id)
        {
            return _context.ThoiKyQuocHieus.Any(e => e.MaTrieuDai == id);
        }
    }
}