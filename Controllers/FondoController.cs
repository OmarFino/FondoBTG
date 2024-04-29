using FondoBTG.Models;
using FondoBTG.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FondoBTG.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FondoController : Controller
    {
        private IFondoCollection db = new FondoCollection();

        
        [HttpGet]
        public async Task<IActionResult> GetAllFondo()
        {
            return Ok(await db.GetAllFondo());
        }

        [HttpGet]
        [Route("acti")]
        public async Task<IActionResult> GetAllFondoActi()
        {
            return Ok(await db.GetAllFondoActi());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFondo(string id)
        {
            return Ok(await db.GetFondoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFondo([FromBody] Fondo fondo)
        {
            if (fondo == null)
                return BadRequest();

            if (fondo.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The fondo shouldn't be empty");
            }

            await db.InsertFondo(fondo);

            return Created("Created", true);
        }

        [HttpPut]
        [Route("add/{id}")]
        public async Task<IActionResult> UpdateFondo(string id)
        {
             try
        {
           var result = await db.UpdateFondoAdd(id);
            return Ok(result);
        }
            catch (Exception ex)
        {
            return StatusCode(500, $"Error al actualizar el fondo: {ex.Message}");
        }
        }

        [HttpPut]
        [Route("delete/{id}")]
        public async Task<IActionResult> UpdateFondoDelete(string id)
        {
            try
            {
                var result = await db.UpdateFondoDelete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el fondo: {ex.Message}");
            }
        }

    }
}
