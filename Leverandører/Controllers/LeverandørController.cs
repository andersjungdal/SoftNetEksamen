using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leverandører.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leverandører.Controllers
{
    [ApiController]
    //Ocelot.json vil ikke acceptere 'ø' i leverandør.
    [Route("api/leverandoer")]

    public class LeverandørController : ControllerBase
    {
        private readonly ILeverandørService _leverandørService;

        public LeverandørController(ILeverandørService leverandørService)
        {
            _leverandørService = leverandørService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLeverandørerAsync()
        {
            var result = await _leverandørService.GetLeverandørerAsync();
            if (result.Leverandører != null)
            {
                return Ok(result.Leverandører);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeverandørAsync(int id)
        {
            var result = await _leverandørService.GetLeverandørAsync(id);
            if (result.Leverandør != null && result.Leverandør.ID == id)
            {
                return Ok(result.Leverandør);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLeverandørAsync([FromBody] Models.Leverandør leverandør)
        {
            var newleverandør = await _leverandørService.PostLeverandørAsync(leverandør);
            if (newleverandør.Leverandør != null)
            {
                return StatusCode(201);
            }
            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeverandørAsync(int id)
        {
            var leverandør = await _leverandørService.DeleteLeverandørAsync(id);
            if (leverandør.Leverandør != null)
            {
                return Ok(leverandør.Leverandør);
            }
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeverandørAsync([FromBody] Models.Leverandør leverandør, int id)
        {
            var updatedkategori = await _leverandørService.PutLevendørAsync(leverandør, id);
            if (updatedkategori.Leverandør != null)
            {
                return Ok(updatedkategori.Leverandør);
            }
            return StatusCode(204);
        }
    }
}
