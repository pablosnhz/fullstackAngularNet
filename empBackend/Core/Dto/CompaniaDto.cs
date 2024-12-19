using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class CompaniaDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la compania es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre de la compania no puede tener mas de 100 caracteres")]
        public string NombreCompania { get; set; }

        [Required(ErrorMessage = "La direccion de la compania es requerida")]
        [MaxLength(100, ErrorMessage = "La direccion de la compania no puede tener mas de 100 caracteres")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El telefono de la compania es requerido")]
        [MaxLength(30, ErrorMessage = "El telefono de la compania no puede tener mas de 30 caracteres")]
        public string telefono { get; set; }
        public string telefono2 { get; set; }
    }
}