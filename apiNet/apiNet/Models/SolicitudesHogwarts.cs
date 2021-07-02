using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiNet.Models
{

    public class SolicitudesHogwarts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdSolicitud { get; set; }
        [Required]
        [Range(1, 9999999999)]
        public long Identificación { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre debe contener maximo 20 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El apellido debe contener maximo 20 caracteres")]
        public string Apellido { get; set; }
        [Required]
        [Range(1, 99)]
        public int Edad { get; set; }
        [Required]
        public string CasaHogwarts { get; set; }
    }
}
