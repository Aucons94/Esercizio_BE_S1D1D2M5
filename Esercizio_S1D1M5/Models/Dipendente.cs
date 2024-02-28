namespace Esercizio_S1D1M5.Models
{
    public class Dipendente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Coniugato { get; set; }
        public int NumeroFigli { get; set; }
        public string Mansione { get; set; }

        public Dipendente() { }

        public Dipendente(int id, string nome, string cognome, string indirizzo, string codiceFiscale, bool coniugato, int numerofigli, string mansione)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Coniugato = coniugato;
            NumeroFigli = numerofigli;
            Mansione = mansione;
        }
    }
}