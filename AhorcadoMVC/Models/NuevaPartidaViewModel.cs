using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AhorcadoMVC.Models
{
    public class NuevaPartidaViewModel
    {
        [Required]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}