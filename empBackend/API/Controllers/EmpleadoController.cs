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
    public class EmpleadoController : ControllerBase
    {
        // aplicamos el servicio
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        // nos avisa que estamos accediendo al log de companias
        public ILogger<EmpleadoController> _logger;
        public readonly IMapper _mapper;

        public EmpleadoController(ApplicationDbContext db, ILogger<EmpleadoController> logger,
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
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            _logger.LogInformation("Listado de Empleados");
            // incluimos la compania con el include que pertenece a la lista principal 
            var lista = await _db.Empleado.Include(c => c.Compania).ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Empleados";

            return Ok(_response);
        }

        // el getCompania es el id del postCompania que ponemos en el CreateAtRoute
        [HttpGet("{id}", Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Debe enviar el ID");
                _response.Mensaje = "Debe enviar el ID";
                _response.IsExitoso = false;
                return BadRequest(_response);
            }
            // al incluir include salto error en findAsync porque solo acepta id, solucion FirstOrDefaultAsync
            var emp = await _db.Empleado.Include(c => c.Compania).FirstOrDefaultAsync(e => e.Id == id);

            // en el caso de que no exista el ID
            if (emp == null)
            {
                _logger.LogError("Empleado no existe!");
                _response.Mensaje = "Empleado no existe!";
                _response.IsExitoso = false;
                return NotFound(_response);
            }

            _response.Resultado = emp;
            _response.Mensaje = "Informacion del empleado " + emp.Id;

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody] EmpleadoUpsertDto empleadoDto)
        {
            if (empleadoDto == null)
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
            var empleadoExiste = await _db.Empleado.FirstOrDefaultAsync
            (c => c.Apellidos.ToLower() == empleadoDto.Apellidos.ToLower() &&
                c.Nombres.ToLower() == empleadoDto.Nombres.ToLower()
            );

            // comprueba si existe una compania con el mismo nombre
            if (empleadoExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre del empleado ya existe");
                return BadRequest(ModelState);
            }

            // aplicamos el _mapper habiendolo refactorizandolo
            Empleado empleado = _mapper.Map<Empleado>(empleadoDto);

            await _db.Empleado.AddAsync(empleado);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> PutCompania(int id, [FromBody] EmpleadoUpsertDto empleadoDto)
        {
            if (id != empleadoDto.Id)
            {
                return BadRequest("Id de compania no coincide");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // para saber si ya existe la compania en la base de datos y buscarla en miniscula
            var empleadoExiste = await _db.Empleado.FirstOrDefaultAsync
            (c => c.Apellidos.ToLower() == empleadoDto.Apellidos.ToLower() &&
                c.Nombres.ToLower() == empleadoDto.Nombres.ToLower() &&
                c.Id != empleadoDto.Id
            );
            if (empleadoExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre del empleado ya existe");
                return BadRequest(ModelState);
            }

            Compania empleado = _mapper.Map<Compania>(empleadoDto);

            _db.Update(empleado);
            await _db.SaveChangesAsync();
            return Ok(empleado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(int id)
        {
            var empleado = await _db.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            _db.Empleado.Remove(empleado);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}