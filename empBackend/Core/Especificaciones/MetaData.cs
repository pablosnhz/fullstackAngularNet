using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Especificaciones
{
    public class MetaData
    {
        public int CurrentPage { get; set; } // pagina actual
        public int TotalPages { get; set; } // total paginas
        public int PageSize { get; set; } // tamano de la pagina
        public int TotalCount { get; set; } // total de registros

        public bool HasPrevious => CurrentPage > 1; // si hay pagina anterior
        public bool HasNext => CurrentPage < TotalPages; // si hay pagina siguiente
    }
}