using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class EmpleadoReadDto
    {
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Cargo { get; set; }
        public string Compania { get; set; }
    }
}