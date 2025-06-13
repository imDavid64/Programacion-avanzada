using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoMVC.Models
{
    public enum NivelDificultad
    {
        Facil,
        Normal,
        Dificil
    }
    public class Partida
    {
        public int Id { get; set; }

        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }
        /// <Partida>
   
        public int PalabraId { get; set; }
        public Palabra Palabra { get; set; }
        // Palabra
        public NivelDificultad Nivel { get; set; }
        public bool Victoria { get; set; }
        public DateTime Fecha { get; set; }
    }
}