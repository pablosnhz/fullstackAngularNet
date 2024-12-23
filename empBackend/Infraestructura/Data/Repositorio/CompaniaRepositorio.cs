using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestructura.Data.Repositorio.IRepositorio;

namespace Infraestructura.Data.Repositorio
{
    public class CompaniaRepositorio : Repositorio<Compania>, ICompaniaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CompaniaRepositorio(ApplicationDbContext db) : base(db) // al ya tener un db en Repositorio y aplicarlo aca tambien debo hacer uso del Base
        {
            _db = db;

        }
        public void Actualizar(Compania compania)
        {
            var companiaDb = _db.Compania.FirstOrDefault(c => c.Id == compania.Id);
            if (companiaDb != null)
            {
                companiaDb.NombreCompania = compania.NombreCompania;
                companiaDb.Direccion = compania.Direccion;
                companiaDb.Telefono = compania.Telefono;
                companiaDb.Telefono2 = compania.Telefono2;
                _db.SaveChanges();
            }
        }
    }
}