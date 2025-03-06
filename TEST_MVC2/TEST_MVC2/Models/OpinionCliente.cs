using System;
using System.ComponentModel.DataAnnotations;
using TEST_MVC2.Models;

namespace TDDTestingMVC1.Models
{
    public class OpinionCliente
    {
        public int OpinionID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        public int? ProductoID { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; }

        [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
        public string Comentario { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones
        public Cliente Cliente { get; set; }
        
    }
}