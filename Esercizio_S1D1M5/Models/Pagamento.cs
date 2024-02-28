using System;

namespace Esercizio_S1D1M5.Models
{
    public class Pagamento
    {
        public int ID { get; set; }
        public int DipendenteID { get; set; }
        public double Ammontare { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        public Pagamento() { }
        public Pagamento(int idPagamento, int idDipendente, double ammontare, string tipoPagamento, DateTime dataPagamento)
        {
            ID = idPagamento;
            DipendenteID = idDipendente;
            Ammontare = ammontare;
            TipoPagamento = tipoPagamento;
            DataPagamento = dataPagamento;
        }

    }
}