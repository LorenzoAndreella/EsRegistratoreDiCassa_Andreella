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
        public string TipoMateriale { get; set; }

        public CArticoloNonAlimentare(long codice, string descrizione, int prezzo, string tipoMateriale)
            : base(codice, descrizione, prezzo)
        {
            TipoMateriale = tipoMateriale;
        }

        public override int Sconta()
        {
            string tipo = TipoMateriale.ToLower();
            if (tipo == Materiale.carta.ToString() || tipo == Materiale.plastica.ToString() || tipo == Materiale.vetro.ToString())
            {
                Prezzo = Prezzo * 90 / 100;
            }
            return Prezzo;
        }
    }
}
