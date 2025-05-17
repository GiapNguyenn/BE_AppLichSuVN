using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;
using HistoryAPI.Data;

namespace HistoryAPI.Controllers
{
    [Route("api/cau-chuyen")]
    [ApiController]
    public class CauChuyenController : ControllerBase
    {
        private readonly HistoryDbContext _context;

        public CauChuyenController(HistoryDbContext context)
        {
            _context = context;
        }

        // GET: api/cau-chuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CauChuyen>>> GetCauChuyens()
        {
            // Loại bỏ Include vì không còn liên kết
            return await _context.CauChuyens.ToListAsync();
        }

        // GET: api/cau-chuyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CauChuyen>> GetCauChuyen(int id)
        {
            // Loại bỏ Include vì không còn liên kết
            var cauChuyen = await _context.CauChuyens.FindAsync(id);

            if (cauChuyen == null)
            {
                return NotFound();
            }

            return cauChuyen;
        }

        // POST: api/cau-chuyen
        [HttpPost]
        public async Task<ActionResult<CauChuyen>> PostCauChuyen(CauChuyen cauChuyen)
        {
            _context.CauChuyens.Add(cauChuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCauChuyen), new { id = cauChuyen.MaCauChuyen }, cauChuyen);
        }

        // PUT: api/cau-chuyen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauChuyen(int id, CauChuyen cauChuyen)
        {
            if (id != cauChuyen.MaCauChuyen)
            {
                return BadRequest();
            }

            _context.Entry(cauChuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauChuyenExists(id))
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

        // DELETE: api/cau-chuyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauChuyen(int id)
        {
            var cauChuyen = await _context.CauChuyens.FindAsync(id);
            if (cauChuyen == null)
            {
                return NotFound();
            }

            _context.CauChuyens.Remove(cauChuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CauChuyenExists(int id)
        {
            return _context.CauChuyens.Any(e => e.MaCauChuyen == id);
        }
    }
}