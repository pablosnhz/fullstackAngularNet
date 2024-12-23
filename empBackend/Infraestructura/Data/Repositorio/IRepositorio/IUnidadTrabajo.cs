using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Data.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable //IDisposable ocupa solo lo que esta siendo usado y no todo el objeto
    {
        ICompaniaRepositorio Compania { get; }
        IEmpleadoRepositorio Empleado { get; }
        Task Guardar();
    }
}