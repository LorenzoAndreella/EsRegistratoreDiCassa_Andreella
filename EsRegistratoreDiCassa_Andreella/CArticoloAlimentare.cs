using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public class CArticoloAlimentare : CArticolo
    {
        public int AnnoScadenza { get; set; }
        public CArticoloAlimentare(long codice, string descrizione, int prezzo, int annoScadenza)
            : base(codice, descrizione, prezzo)
        {
            AnnoScadenza = annoScadenza;
        }

        public override int Sconta()
        {
            if (AnnoScadenza == DateTime.Now.Year)
            {
                Prezzo = Prezzo * 80 / 100;
            }
            return Prezzo;
        }
    }
}
