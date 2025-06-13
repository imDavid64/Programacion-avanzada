using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AhorcadoMVC.Models;
namespace AhorcadoMVC.Models
{
    public class Jugador
    {
        public int Id { get; set; }  // Identificación única (ej. cédula)
        public string Nombre { get; set; }

        public int Marcador { get; set; }

        public ICollection<Partida> Partidas { get; set; }
    }
}