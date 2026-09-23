using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public class CArticolo
    {
        public long Codice { get; set; }
        public string Descrizione { get; set; }
        public int Prezzo { get; set; }

        public CArticolo(long codice, string descrizione, int prezzo)
        {
            Codice = codice;
            Descrizione = descrizione;
            Prezzo = prezzo;
        }

        public virtual int Sconta()
        {
            int prezzoScontato = Prezzo*95/100;
            Prezzo = prezzoScontato;
            return prezzoScontato;
        }
    }
}
