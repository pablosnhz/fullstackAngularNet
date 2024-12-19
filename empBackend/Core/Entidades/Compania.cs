using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Compania
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la compania es requerido")]
        [MaxLength(100, ErrorMessage = "No sea mayor a 100")]
        public string NombreCompania { get; set; }
        [Required(ErrorMessage = "El nombre de la direccion es requerido")]
        [MaxLength(150, ErrorMessage = "No sea mayor a 150")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El telefono es requerido")]
        [MaxLength(40, ErrorMessage = "No sea mayor a 40")]
        public string Telefono { get; set; }
        [MaxLength(40, ErrorMessage = "No sea mayor a 40")]

        public string Telefono2 { get; set; }
    }
}