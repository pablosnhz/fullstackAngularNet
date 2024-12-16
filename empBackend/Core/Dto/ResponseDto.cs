using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class ResponseDto
    {
        public bool IsExitoso { get; set; } = true;
        public object Resultado { get; set; }
        public string Mensaje { get; set; }
    }
}