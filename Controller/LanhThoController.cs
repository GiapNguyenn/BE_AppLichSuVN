using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;
using HistoryAPI.Data;
using HistoryAPI.Helper;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HistoryAPI.Controllers
{
    [Route("api/lanh-tho")]
    [ApiController]
    public class LanhThoController : ControllerBase
    {
        private readonly HistoryDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LanhThoController(HistoryDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/lanh-tho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanhTho>>> GetLanhThos()
        {
            return await _context.LanhThos.ToListAsync();
        }

        // GET: api/lanh-tho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanhTho>> GetLanhTho(int id)
        {
            var lanhTho = await _context.LanhThos.FindAsync(id);

            if (lanhTho == null)
            {
                return NotFound();
            }

            return lanhTho;
        }

        // POST: api/lanh-tho
        [HttpPost]
        public async Task<ActionResult<LanhTho>> PostLanhTho(LanhTho lanhTho) // Loại bỏ IFormFile file
        {
            _context.LanhThos.Add(lanhTho);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLanhTho), new { id = lanhTho.MaLanhTho }, lanhTho);
        }

        // PUT: api/lanh-tho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanhTho(int id, LanhTho lanhTho) // Loại bỏ IFormFile file
        {
            if (id != lanhTho.MaLanhTho)
            {
                return BadRequest();
            }

            _context.Entry(lanhTho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanhThoExists(id))
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

        // DELETE: api/lanh-tho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanhTho(int id)
        {
            var lanhTho = await _context.LanhThos.FindAsync(id);
            if (lanhTho == null)
            {
                return NotFound();
            }

            // Xóa file (nếu có)
            if (!string.IsNullOrEmpty(lanhTho.BanDoURL))
            {
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, lanhTho.BanDoURL);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.LanhThos.Remove(lanhTho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/upload-image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile image)
        {
            var lanhTho = await _context.LanhThos.FindAsync(id);
            if (lanhTho == null) return NotFound();

            try
            {
                var imageUrl = await FileUploadHelper.SaveImageAsync(image, "uploads/lanhthos"); // Thay đổi thư mục
                lanhTho.BanDoURL = imageUrl;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Upload thành công", imageUrl });
            }
            catch (ArgumentException ex) // Bắt lỗi từ SaveImageAsync
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}"); // Thêm StatusCode
            }
        }

        private bool LanhThoExists(int id)
        {
            return _context.LanhThos.Any(e => e.MaLanhTho == id);
        }
    }
}