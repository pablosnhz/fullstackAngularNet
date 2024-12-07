using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadoObjetos.clases
{
    public class Libro : Publicacion
    {

        public string Descripcion { get => $"El titulo es {this.Titulo}, fue escrito por {this.Autor}"; }

        // ctor constructor, BASE hace referencia al constructor de la clase padre que es Publicacion
        public Libro(string Titulo, String Autor, int Paginas) : base(Titulo, Autor, Paginas)
        {

        }

        // override para sobreescribir el metodo de la clase padre de ObtenerDescripcion en Publicacion
        public override string ObtenerDescripcion()
        {
            return $"Libro: {this.Titulo} escrito por {this.Autor} con {this.Paginas} paginas";
        }
    }
}