using Esercizio_S1D1M5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Esercizio_S1D1M5.Controllers
{
    public class DipendenteController : Controller
    {
        List<Dipendente> dipendenti = new List<Dipendente>();
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GestioneDipendenti"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dipendente dipendente = new Dipendente(
                        Convert.ToInt16(reader["ID"]),
                        reader["nome"].ToString(),
                        reader["cognome"].ToString(),
                        reader["indirizzo"].ToString(),
                        reader["codiceFiscale"].ToString(),
                        Convert.ToBoolean(reader["coniugato"]),
                        Convert.ToInt16(reader["numerofigli"]),
                        reader["mansione"].ToString()
                        );
                    dipendenti.Add(dipendente);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
            return View(dipendenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dipendente dipendente)
        {
            dipendenti.Add(dipendente);

            string connectionString = ConfigurationManager.ConnectionStrings["GestioneDipendenti"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "INSERT INTO Dipendenti (nome, cognome, indirizzo, codiceFiscale, coniugato, numerofigli, mansione) " +
                    "VALUES (@nome, @cognome, @indirizzo, @codiceFiscale, @coniugato, @figli, @mansione)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@codiceFiscale", dipendente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@coniugato", dipendente.Coniugato);
                cmd.Parameters.AddWithValue("@numerofigli", dipendente.NumeroFigli);
                cmd.Parameters.AddWithValue("@mansione", dipendente.Mansione);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }

            return View();
        }
    }
}