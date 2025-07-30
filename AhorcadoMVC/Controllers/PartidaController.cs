using AhorcadoMVC.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AhorcadoMVC.Controllers
{
    public class PartidaController : Controller
    {
        [HttpPost]
        public ActionResult Crear(NuevaPartidaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                TempData["Mensaje"] = "Datos incompletos. Verifica el formulario.";
                return RedirectToAction("Index", "Home");
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string email = modelo.Identificacion + "@demo.com";

                // Verificar si ya existe el usuario por Email
                string checkQuery = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int exists = (int)checkCmd.ExecuteScalar();

                // Insertar usuario si no existe
                if (exists == 0)
                {
                    string insertUser = "INSERT INTO Usuario (Nombre, Email, Contrasena, Rol) VALUES (@Nombre, @Email, @Contrasena, @Rol)";
                    SqlCommand insertCmd = new SqlCommand(insertUser, conn);
                    insertCmd.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Contrasena", "demo123");
                    insertCmd.Parameters.AddWithValue("@Rol", "Jugador");
                    insertCmd.ExecuteNonQuery();
                }

                // Obtener ID del usuario
                string getUserIdQuery = "SELECT Id FROM Usuario WHERE Email = @Email";
                SqlCommand getUserCmd = new SqlCommand(getUserIdQuery, conn);
                getUserCmd.Parameters.AddWithValue("@Email", email);
                int usuarioId = (int)getUserCmd.ExecuteScalar();

                // Crear nueva partida
                string insertPartida = "INSERT INTO Partida (UsuarioId, FechaInicio, Estado) VALUES (@UsuarioId, @FechaInicio, @Estado)";
                SqlCommand partidaCmd = new SqlCommand(insertPartida, conn);
                partidaCmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                partidaCmd.Parameters.AddWithValue("@FechaInicio", DateTime.Now);
                partidaCmd.Parameters.AddWithValue("@Estado", "En curso");
                partidaCmd.ExecuteNonQuery();
            }

            TempData["Mensaje"] = "Partida iniciada correctamente.";
            return RedirectToAction("Index", "Home");
        }
    }
}
