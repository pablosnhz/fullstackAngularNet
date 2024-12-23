using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Data.Repositorio.IRepositorio;

namespace Infraestructura.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        public ApplicationDbContext _db { get; }
        public ICompaniaRepositorio Compania { get; private set; }

        public IEmpleadoRepositorio Empleado { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Compania = new CompaniaRepositorio(db);
            Empleado = new EmpleadoRepositorio(db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}