using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadoObjetos.clases
{
    public class Publicacion
    {
        // prop
        public String Titulo { get; set; }
        // protected se puede usar con herencia y private sin
        public String Autor { get; set; }

        public int Paginas { get; set; }

        public Publicacion(string Titulo, String Autor, int Paginas)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Paginas = Paginas;
        }

        // virtual para aplicar el override
        public virtual string ObtenerDescripcion()
        {
            return $"{this.Titulo} escrito por {this.Autor}";
        }

    }
}