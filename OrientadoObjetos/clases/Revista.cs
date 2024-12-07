using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadoObjetos.clases
{
    // si llamamos a publicacion que es el padre y salta error en Revista es porque quiza no se inicio el ctor a mismo
    public class Revista : Publicacion
    {
        public Revista(string Titulo, String Autor, int Paginas) : base(Titulo, Autor, Paginas)
        {
            this.Precio = Precio;
        }

        public int Precio { get; set; }

        // override para sobreescribir el metodo de la clase padre de ObtenerDescripcion en Publicacion
        public override string ObtenerDescripcion()
        {
            return $"Revista: {this.Titulo} escrito por {this.Autor} con {this.Paginas} paginas";
        }
    }
}