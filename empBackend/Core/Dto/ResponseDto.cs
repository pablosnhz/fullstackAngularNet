using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } = true;
        public object Resultado { get; set; }
        public string Mensaje { get; set; }
    }
}