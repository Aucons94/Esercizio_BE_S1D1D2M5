using Esercizio_S1D1M5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Esercizio_S1D1M5.Controllers
{
    public class PagamentoController : Controller
    {
        List<Pagamento> pagamenti = new List<Pagamento>();
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GestioneDipendenti"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Pagamenti";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pagamento pagamento = new Pagamento(
                        Convert.ToInt16(reader["ID"]),
                        Convert.ToInt16(reader["DipendenteID"]),
                        Convert.ToDouble(reader["Ammontare"]),
                        reader["TipoPagamento"].ToString(),
                        Convert.ToDateTime(reader["DataPagamento"])
                        );
                    pagamenti.Add(pagamento);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
            return View(pagamenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            pagamenti.Add(pagamento);

            string connectionString = ConfigurationManager.ConnectionStrings["GestioneDipendenti"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "INSERT INTO Pagamenti (DipendenteID, Ammontare, TipoPagamento, DataPagamento) " +
                    "VALUES (@DipendenteID, @Ammontare, @TipoPagamento, @DataPagamento)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DipendenteID", pagamento.DipendenteID);
                cmd.Parameters.AddWithValue("@Ammontare", pagamento.Ammontare);
                cmd.Parameters.AddWithValue("@TipoPagamento", pagamento.TipoPagamento);
                cmd.Parameters.AddWithValue("@DataPagamento", pagamento.DataPagamento);

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