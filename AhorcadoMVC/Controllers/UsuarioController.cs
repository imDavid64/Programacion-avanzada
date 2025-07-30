﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using AhorcadoMVC.Models;

namespace AhorcadoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Email, Rol, HighestScore FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Email = reader["Email"].ToString(),
                        Rol = reader["Rol"].ToString(),
                        HighestScore = reader["HighestScore"] as int?
                    });
                }
            }

            return View(usuarios);
        }
    }
}
