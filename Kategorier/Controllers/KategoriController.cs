using System.Linq;
using System.Threading.Tasks;
using Kategorier.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kategorier.Controllers
{
    [ApiController]
    [Route("api/kategori")]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;
        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        [HttpGet]
        public async Task<IActionResult> GetKategorierAsync()
        {
            var result = await _kategoriService.GetKategorierAsync();
            if (result.Kategorier != null)
            {
                return Ok(result.Kategorier);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKategoriAsync(int id)
        {
            var result = await _kategoriService.GetKategoriAsync(id);
            if (result.Kategori != null && result.Kategori.ID.Equals(id))
            {
                return Ok(result.Kategori);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateKategoriAsync([FromBody] Models.Kategori kategori)
        {
            var newkategori = await _kategoriService.PostKategoriAsync(kategori);
            if (newkategori.Kategori != null)
            {
                return StatusCode(201);
            }
            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategoriAsync(int id)
        {
            var kategori = await _kategoriService.DeleteKategoriAsync(id);
            if (kategori.Kategori != null)
            {
                return Ok(kategori.Kategori);
            }
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategoriAsync([FromBody] Models.Kategori kategori, int id)
        {
            var updatedkategori = await _kategoriService.PutKategoriAsync(kategori, id);
            if (updatedkategori.Kategori != null)
            {
                return Ok(updatedkategori.Kategori);
            }
            return StatusCode(204);
        }
    }
}