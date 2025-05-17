using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;
using HistoryAPI.Data;

namespace HistoryAPI.Controllers
{
    [Route("api/nhan-vat")]
    [ApiController]
    public class NhanVatController : ControllerBase
    {
        private readonly HistoryDbContext _context;

        public NhanVatController(HistoryDbContext context)
        {
            _context = context;
        }

        // GET: api/nhan-vat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVat>>> GetNhanVats()
        {
            return await _context.NhanVats.ToListAsync();
        }

        // GET: api/nhan-vat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVat>> GetNhanVat(int id)
        {
            var nhanVat = await _context.NhanVats.FindAsync(id);

            if (nhanVat == null)
            {
                return NotFound();
            }

            return nhanVat;
        }

        // POST: api/nhan-vat
        [HttpPost]
        public async Task<ActionResult<NhanVat>> PostNhanVat(NhanVat nhanVat)
        {
            _context.NhanVats.Add(nhanVat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNhanVat), new { id = nhanVat.MaNhanVat }, nhanVat);
        }

        // PUT: api/nhan-vat/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVat(int id, NhanVat nhanVat)
        {
            if (id != nhanVat.MaNhanVat)
            {
                return BadRequest();
            }

            _context.Entry(nhanVat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVatExists(id))
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

        // DELETE: api/nhan-vat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVat(int id)
        {
            var nhanVat = await _context.NhanVats.FindAsync(id);
            if (nhanVat == null)
            {
                return NotFound();
            }

            _context.NhanVats.Remove(nhanVat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanVatExists(int id)
        {
            return _context.NhanVats.Any(e => e.MaNhanVat == id);
        }
    }
}