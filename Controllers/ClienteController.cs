using FondoBTG.business;
using FondoBTG.Models;
using FondoBTG.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FondoBTG.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private IClienteBusiness db = new ClienteBusiness();

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            try
            {

                if (cliente == null)
                    return BadRequest();

                var result = await db.InsertCliente(cliente);

                return Created("Created", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPrimerCliente()
        {
            try
            {
                return Ok(await db.GetPrimerCliente());

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteId(string id)
        {
            try
            {
                return Ok(await db.GetClienteById(id));

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}/{idFondo}/{valor}")]
        public async Task<IActionResult> AddFondoCliente(string id, string idFondo, double valor)
        {
            try
            {
                if (id == null && idFondo == null && valor == 0)
                    return BadRequest();

                return Ok(await db.AddFondoCliente(id,idFondo,valor));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
