using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : ControllerBase
    {
        // aplicamos el servicio
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public CompaniaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            var lista = await _db.Compania.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de companias";

            return Ok(_response);
        }

        // el getCompania es el id del postCompania que ponemos en el CreateAtRoute
        [HttpGet("{id}", Name = "GetCompania")]
        public async Task<ActionResult<Compania>> GetClient(int id)
        {
            var comp = await _db.Compania.FindAsync(id);
            _response.Resultado = comp;
            _response.Mensaje = "Informacion de la compania " + comp.Id;

            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<Compania>> PostCompania([FromBody] Compania compania)
        {
            await _db.Compania.AddAsync(compania);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCompania", new { id = compania.Id }, compania);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Compania>> PutCompania(int id, [FromBody] Compania compania)
        {
            if (id != compania.Id)
            {
                return BadRequest("Id de compania no coincide");
            }
            _db.Update(compania);
            await _db.SaveChangesAsync();
            return Ok(compania);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Compania>> DeleteCompania(int id)
        {
            var compania = await _db.Compania.FindAsync(id);
            if (compania == null)
            {
                return NotFound();
            }
            _db.Compania.Remove(compania);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}