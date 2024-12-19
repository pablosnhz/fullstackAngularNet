using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        // nos avisa que estamos accediendo al log de companias
        public ILogger<CompaniaController> _logger;
        public readonly IMapper _mapper;

        public CompaniaController(ApplicationDbContext db, ILogger<CompaniaController> logger,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _logger = logger;
            _db = db;
            _response = new ResponseDto();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            _logger.LogInformation("Listado de companias");
            var lista = await _db.Compania.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de companias";

            return Ok(_response);
        }

        // el getCompania es el id del postCompania que ponemos en el CreateAtRoute
        [HttpGet("{id}", Name = "GetCompania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compania>> GetClient(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Debe enviar el ID");
                _response.Mensaje = "Debe enviar el ID";
                _response.IsExitoso = false;
                return BadRequest(_response);
            }

            var comp = await _db.Compania.FindAsync(id);

            // en el caso de que no exista el ID
            if (comp == null)
            {
                _logger.LogError("Compania no existe!");
                _response.Mensaje = "Compania no existe!";
                _response.IsExitoso = false;
                return NotFound(_response);
            }

            _response.Resultado = comp;
            _response.Mensaje = "Informacion de la compania " + comp.Id;

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compania>> PostCompania([FromBody] CompaniaDto companiaDto)
        {
            if (companiaDto == null)
            {
                _response.Mensaje = "Informacion Incorrecta";
                _response.IsExitoso = false;
                return BadRequest(_response);
            }

            // ModelState para validar Compania al usar esto debemos ir al 
            // core/entidades/compana y poner las validaciones
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // para saber si ya existe la compania en la base de datos y buscarla en miniscula
            var companiaExiste = await _db.Compania.FirstOrDefaultAsync
            (c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower());

            // comprueba si existe una compania con el mismo nombre
            if (companiaExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre de la compania ya existe");
                return BadRequest(ModelState);
            }

            // aplicamos el _mapper habiendolo refactorizandolo
            Compania compania = _mapper.Map<Compania>(companiaDto);

            await _db.Compania.AddAsync(compania);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCompania", new { id = compania.Id }, compania);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compania>> PutCompania(int id, [FromBody] CompaniaDto companiaDto)
        {
            if (id != companiaDto.Id)
            {
                return BadRequest("Id de compania no coincide");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // para saber si ya existe la compania en la base de datos y buscarla en miniscula
            var companiaExiste = await _db.Compania.FirstOrDefaultAsync
            (c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower()
            && c.Id != companiaDto.Id);

            if (companiaExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre de la compania ya existe");
                return BadRequest(ModelState);
            }

            Compania compania = _mapper.Map<Compania>(companiaDto);

            _db.Update(compania);
            await _db.SaveChangesAsync();
            return Ok(compania);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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