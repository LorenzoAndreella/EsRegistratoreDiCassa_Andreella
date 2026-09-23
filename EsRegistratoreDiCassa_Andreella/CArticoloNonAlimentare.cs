using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public enum Materiale
    {
        vetro,
        carta,
        plastica
    }
    public class CArticoloNonAlimentare : CArticolo
    {
        

        public Materiale TipoMateriale { get; set; }

        public CArticoloNonAlimentare(long codice, string descrizione, int prezzo, Materiale tipoMateriale)
            : base(codice, descrizione, prezzo)
        {
            TipoMateriale = tipoMateriale;
        }

        public override int Sconta()
        {
            if (TipoMateriale == Materiale.carta)
            {
                Prezzo = Prezzo * 90 / 100;
            }
            return Prezzo;
        }
    }
}
