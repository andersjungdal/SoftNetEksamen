using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produkter.Interfaces;

namespace Produkter.Controllers
{
    [ApiController]
    [Route("api/produkt")]

    public class ProduktController : ControllerBase
    {
        private readonly IProduktService _produktService;
        public ProduktController(IProduktService produktService)
        {
            _produktService = produktService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProdukterAsync()
        {
            var result = await _produktService.GetProdukterAsync();
            if (result.Produkter != null)
            {
                return Ok(result.Produkter);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduktAsync(int id)
        {
            var result = await _produktService.GetProduktAsync(id);
            if (result.Produkt != null && result.Produkt.ID == id)
            {
                return Ok(result.Produkt);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduktAsync([FromBody] Models.Produkt produkt)
        {
            var newprodukt = await _produktService.PostProduktAsync(produkt);
            if (newprodukt.Produkt != null)
            {
                return StatusCode(201);
            }
            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduktAsync(int id)
        {
            var produkt = await _produktService.DeleteProduktAsync(id);
            if (produkt.Produkt != null)
            {
                return Ok(produkt.Produkt);
            }
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduktAsync([FromBody] Models.Produkt produkt, int id)
        {
            var updatedprodukt = await _produktService.PutProduktAsync(produkt, id);
            if (updatedprodukt.Produkt != null)
            {
                return Ok(updatedprodukt.Produkt);
            }
            return StatusCode(204);
        }
    }
}
