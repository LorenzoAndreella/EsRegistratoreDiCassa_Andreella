using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public class CCliente
    {
        public List<CArticolo> Articoli { get; set; }
        public bool TesseraFedelta { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public CCliente(string nome, string cognome, bool tessera)
        {
            TesseraFedelta = tessera;
            Nome = nome;
            Cognome = cognome;
            Articoli = new List<CArticolo>();
        }

        public void AggiungiArticolo(CArticolo articolo)
        {
            Articoli.Add(articolo);
        }

        public void Sconta()
        {
            if (TesseraFedelta)
            {
                foreach (CArticolo articolo in Articoli)
                {
                    articolo.Sconta();
                }
            }
        }

    }
}
